﻿using Machine.Steps.ViewModels.Extensions.LinkMovementsItems;
using Machine.Steps.ViewModels.Interfaces;
using Machine.ViewModels.Interfaces;
using Machine.ViewModels.Interfaces.Links;
using Machine.ViewModels.Messages;
using Machine.ViewModels.Messages.Links;
using Machine.ViewModels.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Machine.Steps.ViewModels.Extensions
{
    public class LinkMovementManager : ILinkMovementManager
    {
        List<LinearLinkMovementItem> _items = new List<LinearLinkMovementItem>();
        Dictionary<int, LinksMovementsGroup> _itemsGroups = new Dictionary<int, LinksMovementsGroup>();
        object _lockObj1 = new object();
        object _lockObj2 = new object();
        DateTime _lastProcess;
        bool _firtProcessCall;
        int _processing = 0;

        private IProcessCaller _processCaller;
        private IProcessCaller ProcessCaller => _processCaller ?? (_processCaller = Machine.ViewModels.Ioc.SimpleIoc<IProcessCaller>.GetInstance());

        //private IDispatcherHelper _dispatcherHelper;
        //private IDispatcherHelper DispatcherHelper => _dispatcherHelper ?? (_dispatcherHelper = Machine.ViewModels.Ioc.SimpleIoc<IDispatcherHelper>.GetInstance());

        private IMessenger _messenger;
        private IMessenger Messenger => _messenger ?? (_messenger = Machine.ViewModels.Ioc.SimpleIoc<IMessenger>.GetInstance());

        public int MinTimespam { get; set; } = 50;
        public bool Enable 
        { 
            get => ProcessCaller.Enable;
            set
            {
                if(ProcessCaller.Enable != value)
                {
                    if(value)
                    {
                        _firtProcessCall = true;
                        ProcessCaller.ProcessRequest += OnProcess;
                        ProcessCaller.Enable = true;
                    }
                    else
                    {
                        ProcessCaller.Enable = false;
                        ProcessCaller.ProcessRequest -= OnProcess;
                    }
                }                
            }
        }

        public void Add(int linkId, double value, double targetValue, double duration, int notifyId)
        {
            lock (_lockObj1)
            {
                _items.Add(new LinearLinkMovementItem(linkId, value, targetValue, duration, notifyId));
            }
        }

        public void Add(int groupId, int linkId, double value, double targetValue, double duration, int notifyId)
        {
            lock (_lockObj2)
            {
                if (!_itemsGroups.TryGetValue(groupId, out LinksMovementsGroup group))
                {
                    group = new LinksMovementsGroup(groupId, duration, notifyId);
                    _itemsGroups.Add(groupId, group);
                }

                group.Add(linkId, value, targetValue);
            }
        }

        public void Add(int linkId, double targetValue, double duration, ILinkMovementManager.ArcComponentData data, int notifyId)
        {
            lock (_lockObj2)
            {
                if (!_itemsGroups.TryGetValue(data.GroupId, out LinksMovementsGroup group))
                {
                    group = new LinksMovementsGroup(data.GroupId, duration, notifyId);
                    _itemsGroups.Add(data.GroupId, group);
                }

                group.Add(linkId, targetValue, data);
            }
        }

        private void OnProcess(object sender, DateTime e)
        {
            if (Interlocked.CompareExchange(ref _processing, 1, 0) == 0)
            {
                if (_firtProcessCall)
                {
                    _lastProcess = e;
                    _firtProcessCall = false;
                }
                else
                {
                    var elapse = e - _lastProcess;

                    if (elapse >= TimeSpan.FromMilliseconds(MinTimespam))
                    {
                        _lastProcess = e;
                        EvaluateItems(e);
                        EvaluateGroups(e);
                    }
                }

                Interlocked.Exchange(ref _processing, 0);
            }
        }

        private void EvaluateGroups(DateTime now)
        {
            lock (_lockObj2)
            {
                foreach (var ig in _itemsGroups.Values)
                {
                    ig.Progress(now);

                    ig.Items.ForEach((i) => SetLinkValue(i.LinkId, i.ActualValue));
                    
                    if(ig.IsCompleted && (ig.NotifyId > 0)) Messenger.Send(new ActionExecutedMessage() { Id = ig.NotifyId });
                }

                _itemsGroups = _itemsGroups.Where(ig => !ig.Value.IsCompleted).ToDictionary(kp => kp.Key, kp => kp.Value);
            }
        }

        private void EvaluateItems(DateTime now)
        {
            lock (_lockObj1)
            {
                _items.ForEach(i =>
                {
                    i.Progress(now);

                    SetLinkValue(i.LinkId, i.ActualValue);

                    if(i.IsCompleted && i.NotifyId > 0) Messenger.Send(new ActionExecutedMessage() { Id = i.NotifyId });
                });

                _items = _items.Where((ii) => !ii.IsCompleted).ToList();
            }
        }

        private void SetLinkValue(int linkId, double value)
        {
            Messenger.Send(new GetLinkMessage()
            {
                Id = linkId,
                SetLink = (link) =>
                {
                    link.Value = value;
                }
            });
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using MVMME = Machine.ViewModels.MachineElements;
using MaterialRemove.Interfaces;
using System.Threading.Tasks;
using MaterialRemove.ViewModels;
using MaterialRemove.ViewModels.Extensions;
using System.Linq;
using MVMI = Machine.ViewModels.Interfaces.Tools;
using Machine.ViewModels.Interfaces.MachineElements;
using Machine.Data.Base;
using Machine.ViewModels.MachineElements;
using Machine.ViewModels.UI;
using MVMIoc = Machine.ViewModels.Ioc;
using Machine.ViewModels.Interfaces;
using MRVMI = MaterialRemove.ViewModels.Interfaces;
using MaterialRemove.Interfaces.Enums;

namespace MaterialRemove.Machine.Bridge
{
    class PanelViewModel : MVMME.PanelViewModel, IPanel, MVMI.IToolsObserver
    {
        private PanelSectionsProxy _panelSectionsProxy;
        private ToolsObserver _toolsObserver;
        private IProgressState _stepsProgressState;

        public int NumCells { get; set; }
        public int SectionsX100mm { get; set; }
        public double CubeSize { get; set; }
        public double FilterMargin { get; set; }
        public PanelFragment PanelFragment { get; set; }
        public int SectionDivision { get; set; }

        public IList<IPanelSection> Sections => (_panelSectionsProxy != null) ? _panelSectionsProxy.Sections : null;
        public IEnumerable<ISectionFace> Faces => (_panelSectionsProxy != null) ? Sections.SelectMany(s => s.Faces) : null;
        public IEnumerable<ISectionVolume> Volumes => ((_panelSectionsProxy != null) && (_panelSectionsProxy.Sections.Any(s => s.Volume != null))) ? Sections.Select(s => s.Volume) : null;


        public void Initialize()
        {
            _panelSectionsProxy = new PanelSectionsProxy() { Sections = this.CreateSections(), DispatcherHelper = new DispatcherHelperProxy() };
            _toolsObserver = new ToolsObserver(this);
            (GetInstance<MVMI.IToolObserverProvider>() as ToolsObserverProvider).Observer = this;
            _stepsProgressState = GetInstance<IProgressState>();

            if(_stepsProgressState != null) _stepsProgressState.ProgressIndexChanged += OnProgressIndexChanged;

            SetProbableElementProxy();
            GetInstance<IPanelExportController>().Panel = this;
        }

        public void ApplyAction(ToolActionData toolActionData)
        {
            if ((_stepsProgressState != null) && (_stepsProgressState.ProgressDirection == ProgressDirection.Back)) return;

            _panelSectionsProxy.ApplyAction(this, toolActionData);
        }

        public Task ApplyActionAsync(ToolActionData toolActionData)
        {
            return Task.Run(async () =>
            {
                if ((_stepsProgressState != null) && (_stepsProgressState.ProgressDirection == ProgressDirection.Back)) return;

                await _panelSectionsProxy.ApplyActionAsync(this, toolActionData);                
            });
        }

        public void ApplyAction(ToolSectionActionData toolSectionActionData)
        {
            if ((_stepsProgressState != null) && (_stepsProgressState.ProgressDirection == ProgressDirection.Back)) return;

            _panelSectionsProxy.ApplyAction(this, toolSectionActionData);
        }

        public Task ApplyActionAsync(ToolSectionActionData toolSectionActionData)
        {
            return Task.Run(async () =>
            {
                if ((_stepsProgressState != null) && (_stepsProgressState.ProgressDirection == ProgressDirection.Back)) return;

                await _panelSectionsProxy.ApplyActionAsync(this, toolSectionActionData);
            });
        }

        public void ApplyAction(ToolConeActionData toolConeActionData)
        {
            if ((_stepsProgressState != null) && (_stepsProgressState.ProgressDirection == ProgressDirection.Back)) return;

            _panelSectionsProxy.ApplyAction(this, toolConeActionData);
        }

        public Task ApplyActionAsync(ToolConeActionData toolConeActionData)
        {
            return Task.Run(async () =>
            {
                if ((_stepsProgressState != null) && (_stepsProgressState.ProgressDirection == ProgressDirection.Back)) return;

                await _panelSectionsProxy.ApplyActionAsync(this, toolConeActionData);
            });
        }

        private void OnProgressIndexChanged(object sender, int e)
        {
            if(_stepsProgressState.ProgressDirection == ProgressDirection.Back)
            {
                //_panelSectionsProxy.RemoveData(e);
                _panelSectionsProxy.RemoveActionAsync(e);
                RemoveIndexedChildrenAsyn(e);
            }
        }

        private void RemoveIndexedChildren(int index)
        {
            var items = new List<IMachineElement>();

            foreach (var item in Children)
            {
                if((item is IIndexed idx) && (idx.Index == index)) items.Add(item);
            }

            if (items.Count() > 0)
            {
                foreach (var item in items)
                {
                    MVMIoc.SimpleIoc<IDispatcherHelper>.GetInstance().CheckBeginInvokeOnUi(() =>
                    {
                        Children.Remove(item);
                    });
                }
            }
        }

        private Task RemoveIndexedChildrenAsyn(int index)
        {
            return Task.Run(() => RemoveIndexedChildren(index));
        }

        public void Register(IToolElement tool) => _toolsObserver.Register(tool);

        public void Unregister(IToolElement tool) => _toolsObserver.Unregister(tool);

        protected override void Dispose(bool disposing)
        {
            (GetInstance<MVMI.IToolObserverProvider>() as ToolsObserverProvider).Observer = null;
            if (_toolsObserver != null) _toolsObserver.Dispose();
            if (_stepsProgressState != null) _stepsProgressState.ProgressIndexChanged -= OnProgressIndexChanged;
            _stepsProgressState = null;
            GetInstance<IPanelExportController>().Panel = null;

            base.Dispose(disposing);
        }

        private void Trace(ToolActionData toolActionData)
        {
            MVMIoc.SimpleIoc<IDispatcherHelper>.GetInstance().CheckBeginInvokeOnUi(() =>
            {
                Children.Add(new DebugElementViewModel(toolActionData.X, toolActionData.Y, toolActionData.Z));
            });
        }

        private void SetProbableElementProxy()
        {
            if ((_panelSectionsProxy != null) && (_panelSectionsProxy.Sections != null))
            {
                foreach (var section in _panelSectionsProxy.Sections)
                {
                    foreach (var item in section.Faces)
                    {
                        if (item is MRVMI.IProbableElementProxy pep)
                        {
                            pep.SetProbableElement(this);
                        }
                    }

                    if (section.Volume is MRVMI.IProbableElementProxy vpep)
                    {
                        vpep.SetProbableElement(this);
                    }
                }
            }
        }
    }
}

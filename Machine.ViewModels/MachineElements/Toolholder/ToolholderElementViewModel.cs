﻿using Machine.Data.Base;
using Machine.Data.Enums;
using Machine.ViewModels.Messages.Tooling;

namespace Machine.ViewModels.MachineElements.Toolholder
{
    public abstract class ToolholderElementViewModel : ElementViewModel
    {
        private static Color _toolColor = new Color() { A = 255, B = 255 };
        private static Color _coneColor = new Color() { A = 255, B = 128, G = 128, R = 128 };

        public int ToolHolderId { get; set; }
        public abstract ToolHolderType ToolHolderType { get; }
        public Vector Position { get; set; }
        public Vector Direction { get; set; }

        public ToolholderElementViewModel() : base()
        {
            Messenger.Register<LoadToolMessage>(this, OnLoadToolMessage);
            Messenger.Register<UnloadToolMessage>(this, OnUnloadToolMessage);
            Messenger.Register<UnloadAllToolMessage>(this, OnUnloadAllToolMessage);
            Messenger.Register<AngularTransmissionLoadMessage>(this, OnAngularTransmissionLoadMessage);
        }

        protected virtual void OnAngularTransmissionLoadMessage(AngularTransmissionLoadMessage msg)
        {
            if (msg.ToolHolder == ToolHolderId)
            {
                var vm = new AngularTransmissionViewModel()
                {
                    Name = msg.AngularTransmission.Name,
                    Tool = msg.AngularTransmission,
                    IsVisible = true,
                    Parent = this
                };

                msg.AppendSubSpindle((p, v, t) => vm.AppendSubSpindle(p, v, t));

                Children.Add(vm);
            }
        }

        protected virtual void OnLoadToolMessage(LoadToolMessage msg)
        {
            if (msg.ToolHolder == ToolHolderId)
            {
                var vm = new ToolViewModel()
                {
                    Name = msg.Tool.Name,
                    Tool = msg.Tool,
                    Color = _toolColor,
                    ConeColor = _coneColor,
                    IsVisible = true,
                    Parent = this
                };

                Children.Add(vm);               
            }
        }

        protected virtual void OnUnloadToolMessage(UnloadToolMessage msg)
        {
            if (msg.ToolHolder == ToolHolderId)
            {
                foreach (var item in Children) item.Parent = null;
                Children.Clear();
            }
        }

        protected virtual void OnUnloadAllToolMessage(UnloadAllToolMessage msg)
        {
            foreach (var item in Children) item.Parent = null;
            Children.Clear();
        }
    }
}

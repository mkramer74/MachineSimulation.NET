﻿using Machine.Data.Enums;
using Machine.ViewModels.Interfaces.Links;
using Machine.ViewModels.Messages.Links;
using Machine.ViewModels.Messages.Links.Gantry;
using Machine.ViewModels.UI.Attributes;

namespace Machine.ViewModels.Links
{
    [Link("Linear")]
    public class LinearLinkViewModel : LinkViewModel, ILinearLinkViewModel, ILinkViewModel
    {
        #region private field
        private double _gantryGap;
        #endregion

        #region data properties
        private double _min;
        public double Min 
        { 
            get => _min; 
            set => Set(ref _min, value, nameof(Min)); 
        }

        private double _max;
        public double Max 
        { 
            get => _max; 
            set => Set(ref _max, value, nameof(Max)); 
        }

        private double _pos;
        public double Pos 
        { 
            get => _pos; 
            set => Set(ref _pos, value, nameof(Pos)); 
        }
        #endregion

        #region view properties4
        public override LinkMoveType MoveType => LinkMoveType.Linear;
        #endregion

        #region ctor
        public LinearLinkViewModel() : base()
        {
            Messenger.Register<GantryMessage>(this, OnGantryMessage);
        }
        #endregion

        #region messages handlers
        private void OnGantryMessage(GantryMessage msg)
        {
            if (msg.Slave == Id)
            {
                Messenger.Send(new GetLinkMessage()
                {
                    Id = msg.Master,
                    SetLink = (link) =>
                    {
                        _gantryGap = Value - link.Value;

                        if (msg.State)
                        {
                            link.ValueChanged += OnGantryMasterChanged;
                        }
                        else
                        {
                            link.ValueChanged -= OnGantryMasterChanged;
                        }
                    }
                });
            }
        }
        #endregion

        #region private methods
        private void OnGantryMasterChanged(object sender, double e) => Value = e + _gantryGap;
        #endregion
    }
}

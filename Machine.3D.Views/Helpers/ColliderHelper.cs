﻿using Machine.ViewModels.Interfaces;
using Machine.ViewModels.MachineElements;
using System.Linq;
using System.Windows.Media.Media3D;

namespace Machine._3D.Views.Helpers
{
    class ColliderHelper : BaseColliderHelper, IColliderHelper
    {
        ColliderElementViewModel _collider;
        PanelViewModel _panel;

        public ColliderHelper(ColliderElementViewModel collider, PanelViewModel panel)
        {
            _collider = collider;
            _panel = panel;
        }

        protected override Point3D[] GetColliderPoints() => _collider.Points.Select(p => new Point3D(p.X, p.Y, p.Z)).ToArray();
        protected override Vector3D GetColliderDirection() => new Vector3D(_collider.CollidingDirection.X, _collider.CollidingDirection.Y, _collider.CollidingDirection.Z);
        protected override Point3D GetPanelCenter() => new Point3D(_panel.CenterX, _panel.CenterY, _panel.CenterZ);
        protected override Size3D GetPanelSize() => new Size3D(_panel.SizeX, _panel.SizeY, _panel.SizeZ);
        protected override Matrix3D GetColliderChainTransformation() => _collider.GetChainTransformation();
        protected override Matrix3D GetPanelChainTransformation() => _panel.GetChainTransformation();
    }
}

﻿using Machine._3D.Views.Converters;
using Machine.Data.Enums;
using Machine.ViewModels.Links;
using Machine.ViewModels.MachineElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Machine._3D.Views.Helpers
{
    static class ElementViewModelTransformExtension
    {
        public static Matrix3D GetChainTransformation(this ElementViewModel endOfChain)
        {
            ElementViewModel p = endOfChain;
            var list = new List<ElementViewModel>();
            var matrix = Matrix3D.Identity;

            while (p != null)
            {
                list.Insert(0, p);
                p = p.Parent;
            }

            for (int i = 0; i < list.Count; i++) matrix.Append(GetElementTransformation(list[i]));

            return matrix;
        }

        private static Matrix3D GetElementTransformation(ElementViewModel e)
        {
            if ((e == null) || (e.Transformation == null))
            {
                return Matrix3D.Identity;
            }
            else
            {
                var ts = StaticTransformationConverter.Convert(e.Transformation);

                if (e.LinkToParent != null)
                {
                    var tl = GetLinkTransformation(e.LinkToParent);

                    ts.Append(tl);
                }

                return ts;
            }
        }

        private static Matrix3D GetLinkTransformation(LinkViewModel link)
        {
            switch (link.MoveType)
            {
                case Data.Enums.LinkMoveType.Linear:
                    return GetLinearLinkTransformation(link as LinearLinkViewModel);
                case Data.Enums.LinkMoveType.Pneumatic:
                    return GetPenumaticLinkTRansformation(link as PneumaticLinkViewModel);
                default:
                    throw new ArgumentOutOfRangeException();
            }
            throw new NotImplementedException();
        }

        private static Matrix3D GetPenumaticLinkTRansformation(PneumaticLinkViewModel link)
        {
            switch (link.Type)
            {
                case LinkType.Linear:
                    return GetLinearTransformation(link.Direction, link.Value);
                case LinkType.Rotary:
                    return GetRataryTransformation(link.Direction, link.Value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Matrix3D GetLinearLinkTransformation(LinearLinkViewModel link)
        {
            switch (link.Type)
            {
                case Data.Enums.LinkType.Linear:
                    return GetLinearTransformation(link.Direction, link.Value, link.Pos);
                case Data.Enums.LinkType.Rotary:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Matrix3D GetLinearTransformation(LinkDirection direction, double value, double pos = 0.0)
        {
            var matrix = Matrix3D.Identity;
            var v = value - pos;

            switch (direction)
            {
                case Data.Enums.LinkDirection.X:
                    matrix.OffsetX = v;
                    break;
                case Data.Enums.LinkDirection.Y:
                    matrix.OffsetY = v;
                    break;
                case Data.Enums.LinkDirection.Z:
                    matrix.OffsetZ = v;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return matrix;
        }

        private static Matrix3D GetRataryTransformation(LinkDirection direction, double value, double pos = 0.0)
        {
            double x = 0.0, y = 0.0, z = 0.0;
            var matrix = Matrix3D.Identity;
            var v = value - pos;

            switch (direction)
            {
                case LinkDirection.X:
                    x = 1.0;
                    break;
                case LinkDirection.Y:
                    y = 1.0;
                    break;
                case LinkDirection.Z:
                    z = 1.0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            matrix.Rotate(new Quaternion(new Vector3D(x, y, z), v));

            return matrix;
        }

    }
}

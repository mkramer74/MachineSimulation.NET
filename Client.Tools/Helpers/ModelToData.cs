﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT = MachineModels.Models.Tools;
using MDT = Machine.Data.Tools;
using MME = MachineModels.Enums;
using MDE = Machine.Data.Enums;

namespace Client.Tools.Helpers
{
    static class ModelToData
    {
        public static MDT.ToolSet ToToolsData(this MMT.ToolSet toolset)
        {
            var ts = new MDT.ToolSet();

            foreach (var item in toolset.Tools)
            {
                ts.Tools.Add(item.ToData());
            }

            return ts;
        }

        private static MDT.Tool ToData(this MMT.Tool tool)
        {
            switch (tool.ToolType)
            {
                case MachineModels.Enums.ToolType.Simple:
                    return ToSimple(tool);
                case MachineModels.Enums.ToolType.TwoSection:
                    return ToTwoSection(tool);
                case MachineModels.Enums.ToolType.Pointed:
                    return ToPointed(tool);
                case MachineModels.Enums.ToolType.Disk:
                    return ToDisk(tool);
                case MachineModels.Enums.ToolType.Countersink:
                    return ToCountersink(tool);
                case MachineModels.Enums.ToolType.DiskOnCone:
                    return ToDiskOnCone(tool);
                default:
                    throw new NotImplementedException();
            }
        }

        private static MDT.Tool ToSimple(MMT.Tool tool)
        {
            var t = new MDT.SimpleTool();
            var simpleTool = tool as MMT.SimpleTool;

            t.Diameter = simpleTool.Diameter;
            t.Length = simpleTool.Length;
            t.UsefulLength = simpleTool.UsefulLength;

            UpdateBaseData(t, tool);

            return t;
        }

        private static MDT.Tool ToTwoSection(MMT.Tool tool)
        {
            var t = new MDT.TwoSectionTool();
            var tst = tool as MMT.TwoSectionTool;

            t.Diameter1 = tst.Diameter1;
            t.Diameter2 = tst.Diameter2;
            t.Length1 = tst.Length1;
            t.Length2 = tst.Length2;

            UpdateBaseData(t, tool);

            return t;
        }

        private static MDT.Tool ToPointed(MMT.Tool tool)
        {
            var t = new MDT.PointedTool();
            var pt = tool as MMT.PointedTool;

            t.ConeHeight = pt.ConeHeight;
            t.Diameter = pt.Diameter;
            t.StraightLength = pt.StraightLength;
            t.UsefulLength = pt.UsefulLength;

            UpdateBaseData(t, tool);

            return t;
        }

        private static MDT.Tool ToDisk(MMT.Tool tool)
        {
            var t = new MDT.DiskTool();
            var dt = tool as MMT.DiskTool;

            t.Diameter = dt.Diameter;
            t.CuttingRadialThickness = dt.CuttingRadialThickness;
            t.BodyThickness = dt.BodyThickness;
            t.CuttingThickness = dt.CuttingThickness;
            t.RadialUsefulLength = dt.RadialUsefulLength;

            UpdateBaseData(t, tool);

            return t;
        }

        private static MDT.Tool ToCountersink(MMT.Tool tool)
        {
            var t = new MDT.CountersinkTool();
            var cst = tool as MMT.CountersinkTool;

            t.Diameter1 = cst.Diameter1;
            t.Diameter2 = cst.Diameter2;
            t.Length1 = cst.Length1;
            t.Length2 = cst.Length2;
            t.Length3 = cst.Length3;
            t.UsefulLength = cst.UsefulLength;

            UpdateBaseData(t, tool);

            return t;
        }

        private static MDT.Tool ToDiskOnCone(MMT.Tool tool)
        {
            var t = new MDT.DiskOnConeTool();
            var dct = tool as MMT.DiskOnConeTool;

            t.Diameter = dct.Diameter;
            t.CuttingRadialThickness = dct.CuttingRadialThickness;
            t.BodyThickness = dct.BodyThickness;
            t.CuttingThickness = dct.CuttingThickness;
            t.RadialUsefulLength = dct.RadialUsefulLength;
            t.PostponemntDiameter = dct.PostponemntDiameter;
            t.PostponemntLength = dct.PostponemntLength;

            UpdateBaseData(t, tool);

            return t;
        }

        private static void UpdateBaseData(MDT.Tool dest, MMT.Tool source)
        {
            dest.Name = source.Name;
            dest.Description = source.Description;
            dest.ConeModelFile = source.ConeModelFile;
            dest.ToolLinkType = ConvertLinkType(source.ToolLinkType);
        }

        private static MDE.ToolLinkType ConvertLinkType(MME.ToolLinkType type)
        {
            switch (type)
            {
                case MME.ToolLinkType.Static:
                    return MDE.ToolLinkType.Static;
                case MME.ToolLinkType.Auto:
                    return MDE.ToolLinkType.Auto;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

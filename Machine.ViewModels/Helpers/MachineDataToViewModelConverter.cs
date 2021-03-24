﻿using Machine.ViewModels.Links;
using Machine.ViewModels.MachineElements;
using System;
using System.Collections.Generic;
using System.Text;
using MD = Machine.Data;
using MDE = Machine.Data.MachineElements;
using MDL = Machine.Data.Links;

namespace Machine.ViewModels.Helpers
{
    public static class MachineDataToViewModelConverter
    {
        public static ElementViewModel ToViewModel(this MDE.MachineElement me)
        {
            if (me is MDE.RootElement re) return Convert(re);
            else if (me is MDE.InserterElement ins) return Convert(ins);
            else if (me is MDE.InjectorElement inj) return Convert(inj);
            else if (me is MDE.ColliderElement ce) return Convert(ce);
            else if (me is MDE.ToolholderElement th) return Convert(th);
            else if (me is MDE.PanelHolderElement ph) return Convert(ph);
            else return Convert<ElementViewModel>(me);
        }

        private static RootElementViewModel Convert(MDE.RootElement re)
        {
            var revm = Convert<RootElementViewModel>(re);

            revm.AssemblyName = re.AssemblyName;
            revm.RootType = re.RootType;

            return revm;
        }

        private static ColliderElementViewModel Convert(MDE.ColliderElement ce)
        {
            var vm = Convert<ColliderElementViewModel>(ce);

            return vm;
        }
        private static ToolholderElementViewModel Convert(MDE.ToolholderElement th)
        {
            var vm = Convert<ToolholderElementViewModel>(th);

            vm.ToolHolderId = th.ToolHolderId;
            vm.ToolHolderType = th.ToolHolderType;
            vm.Position = th.Position;
            vm.Direction = th.Direction;

            return vm;
        }
        private static PanelHolderElementViewModel Convert(MDE.PanelHolderElement ph)
        {
            var vm = Convert<PanelHolderElementViewModel>(ph);

            return vm;
        }
        private static InserterElementViewMode Convert(MDE.InserterElement ins)
        {
            var vm = ConverterInserter<InserterElementViewMode>(ins);

            return vm;
        }
        private static InjectorElementViewModel Convert(MDE.InjectorElement inj) => ConverterInserter<InjectorElementViewModel>(inj);


        private static T ConverterInserter<T>(MDE.InjectorElement me) where T : InjectorElementViewModel, new()
        {
            var vm = Convert<T>(me);

            return vm;
        }

        private static T Convert<T>(MDE.MachineElement machineElement) where T : ElementViewModel, new()
        {
            var evm = new T()
            {
                MachineElementID = machineElement.MachineElementID,
                Name = machineElement.Name,
                ModelFile = machineElement.ModelFile,
                Color = machineElement.Color,
                Transformation = machineElement.Transformation,
                LinkToParent = ConvertLink(machineElement.LinkToParent, machineElement.Name)
            };

            foreach (var item in machineElement.Children) evm.Children.Add(item.ToViewModel());

            foreach (var item in evm.Children) item.Parent = evm;

            return evm;
        }

        private static LinkViewModel ConvertLink(MDL.Link linkToParent, string name)
        {
            LinkViewModel vm = null;

            if (linkToParent is MDL.LinearLink linearLink)
            {
                vm = new LinearLinkViewModel()
                {
                    Id = linkToParent.Id,
                    LinkID = linearLink.LinkID,
                    Direction = linearLink.Direction,
                    Type = linearLink.Type,
                    Max = linearLink.Max,
                    Min = linearLink.Min,
                    Pos = linearLink.Pos,
                    Value = linearLink.Pos,
                    Description = name
                };
            }
            else if (linkToParent is MDL.PneumaticLink pneumaticLink)
            {
                vm = new PneumaticLinkViewModel()
                {
                    Id = pneumaticLink.Id,
                    LinkID = pneumaticLink.LinkID,
                    Direction = pneumaticLink.Direction,
                    Type = pneumaticLink.Type,
                    OffPos = pneumaticLink.OffPos,
                    OnPos = pneumaticLink.OnPos,
                    TOff = pneumaticLink.TOff,
                    TOn = pneumaticLink.TOn,
                    ToolActivator = pneumaticLink.ToolActivator,
                    Description = name
                };
            }

            return vm;
        }

    }
}

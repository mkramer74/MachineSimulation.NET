﻿namespace Machine.ViewModels.Interfaces.Links
{
    public interface IPneumaticLinkViewModel : ILinkViewModel
    {
        double OffPos { get; set; }
        double OnPos { get; set; }
        bool State { get; set; }
        double TOff { get; set; }
        double TOn { get; set; }
        bool ToolActivator { get; set; }
    }
}
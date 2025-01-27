﻿using Machine.ViewModels;
using System.Windows;
using MVMUI = Machine.ViewModels.UI;
using MDFJ = Machine.DataSource.File.Json;
using MDFX = Machine.DataSource.File.Xml;
using MDCR = Machine.DataSource.Client.Rest;
using MVUI = Machine.Views.UI;
using MW32 = Microsoft.Win32;
using M3DGPI = Machine._3D.Geometry.Provider.Interfaces;
using M3DGPIM = Machine._3D.Geometry.Provider.Implementation;
using MSFM = Machine.StepsSource.File.Msteps;
using MSFI = Machine.StepsSource.File.Iso;
using MVMI = Machine.ViewModels.Interfaces;
using MSVMI = Machine.Steps.ViewModels.Interfaces;
using MSVME = Machine.Steps.ViewModels.Extensions;
using MVMB = Machine.ViewModels.Base;
using MRVM3D = MaterialRemove.ViewModels._3D;
using MRVMI = MaterialRemove.ViewModels.Interfaces;
using MVMIF = Machine.ViewModels.Interfaces.Factories;
using MRMB = MaterialRemove.Machine.Bridge;
using MRI = MaterialRemove.Interfaces;
using MVMII = Machine.ViewModels.Interfaces.Insertions;
using MVMIns = Machine.ViewModels.Insertions;
using MVMM = Machine.ViewModels.Messaging;

namespace Machine.Viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ViewModels.Ioc.SimpleIoc<MVMI.IKernelViewModel>.Register<KernelViewModel>();
            ViewModels.Ioc.SimpleIoc<MVMM.IMessenger>.Register<MVMM.Messenger>();
            ViewModels.Ioc.SimpleIoc<MVMUI.IDataSource>.Register<MDFJ.DataSource>("File.JSON");
            ViewModels.Ioc.SimpleIoc<MVMUI.IDataSource>.Register<MDFX.DataSource>("File.XML");
            ViewModels.Ioc.SimpleIoc<MVMUI.IDataSource>.Register<MDCR.DataSource>("Client.REST");
            ViewModels.Ioc.SimpleIoc<MVMUI.IFileDialog>.Register<MVUI.FileDialog<MW32.OpenFileDialog>>("OpenFile");
            ViewModels.Ioc.SimpleIoc<MVMUI.IFileDialog>.Register<MVUI.FileDialog<MW32.SaveFileDialog>>("SaveFile");
            ViewModels.Ioc.SimpleIoc<MVMUI.IOptionProvider>.Register(new MVMUI.RegisteredOptionProvider<MVMUI.IDataSource>() { Name = "DataSource" });
            ViewModels.Ioc.SimpleIoc<M3DGPI.IStreamProvider>.Register<M3DGPIM.StlFileStreamProvider>("File.JSON");
            ViewModels.Ioc.SimpleIoc<M3DGPI.IStreamProvider>.Register<M3DGPIM.StlFileStreamProvider>("File.XML");
            ViewModels.Ioc.SimpleIoc<M3DGPI.IStreamProvider>.Register<M3DGPIM.RestApiStreamProvider>("Client.REST");
            ViewModels.Ioc.SimpleIoc<MVMUI.IListDialog>.Register<MVUI.ListDialog>();
            ViewModels.Ioc.SimpleIoc<MVMUI.IStepsSource>.Register<MSFM.StepsSource>("File.msteps");
            ViewModels.Ioc.SimpleIoc<MVMUI.IStepsSource>.Register<MSFI.StepsSource>("File.iso");
            ViewModels.Ioc.SimpleIoc<MSVMI.IDurationProvider>.Register<MSVME.DurationProvider>();
            ViewModels.Ioc.SimpleIoc<MSVMI.IBackStepActionFactory>.Register<MSVME.BackStepActionFactory>();
            ViewModels.Ioc.SimpleIoc<MSVMI.IActionExecuter>.Register<MSVME.ActionExecuter>();
            ViewModels.Ioc.SimpleIoc<MVMUI.IDispatcherHelper>.Register<MVUI.DispatcherHelper>();
            ViewModels.Ioc.SimpleIoc<MVMI.Links.ILinkMovementManager>.Register<MSVME.LinkMovementManager>();
            ViewModels.Ioc.SimpleIoc<MRVMI.IElementViewModelFactory>.Register<MRVM3D.ElementViewModelFactory>();
            ViewModels.Ioc.SimpleIoc<MVMIF.IPanelElementFactory>.Register<MRMB.PanelViewModelFactory>();
            //ViewModels.Ioc.SimpleIoc<MVMIF.IPanelElementFactory>.Register<Machine.ViewModels.Factories.PanelViewModelFactory>();
            ViewModels.Ioc.SimpleIoc<MVMI.Tools.IToolObserverProvider>.Register<MRMB.ToolsObserverProvider>();
            ViewModels.Ioc.SimpleIoc<MRI.IMaterialRemoveData>.Register<MRMB.MaterialRemoveData>();
            ViewModels.Ioc.SimpleIoc<MVMII.IInsertionsSinkProvider>.Register<MVMIns.InsertionsSinkProvider>();
            ViewModels.Ioc.SimpleIoc<MVMI.Probing.IProbeFactory>.Register<ViewModels.Probing.ProbeFactory>();
            ViewModels.Ioc.SimpleIoc<MVMUI.IApplicationInformationProvider>.Register(new MVMUI.ApplicationInformationProvider(MVMUI.ApplicationType.MachineViewer));
            ViewModels.Ioc.SimpleIoc<MVMB.ICommandExceptionObserver>.Register<MVUI.SimpleCommandExceptionObserver>();
            ViewModels.Ioc.SimpleIoc<MVMUI.IExceptionObserver>.Register<MVUI.SimpleExceptionObserver>();
            ViewModels.Ioc.SimpleIoc<MRI.IPanelExportController>.Register<MRMB.PanelExportController>();
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Machine.Viewer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("255, 224, 192")]
        public global::System.Drawing.Color BackgroundColorStart {
            get {
                return ((global::System.Drawing.Color)(this["BackgroundColorStart"]));
            }
            set {
                this["BackgroundColorStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192, 255, 255")]
        public global::System.Drawing.Color BackgroundColorStop {
            get {
                return ((global::System.Drawing.Color)(this["BackgroundColorStop"]));
            }
            set {
                this["BackgroundColorStop"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Sun")]
        public string LightType {
            get {
                return ((string)(this["LightType"]));
            }
            set {
                this["LightType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{\r\n  \"EnableCurrentPosition\": \"False\",\r\n  \"InfiniteSpin\": \"False\",\r\n  \"IsShadowMa" +
            "ppingEnabled\": \"True\",\r\n  \"IsChangeFieldOfViewEnabled\": \"True\",\r\n  \"IsInertiaEna" +
            "bled\": \"False\",\r\n  \"IsPanEnabled\": \"True\",\r\n  \"IsRotationEnabled\": \"True\",\r\n  \"I" +
            "sTouchRotateEnabled\": \"True\",\r\n  \"IsPinchZoomEnabled\": \"True\",\r\n  \"PinchZoomAtCe" +
            "nter\": \"False\",\r\n  \"IsThreeFingerPanningEnabled\": \"True\",\r\n  \"IsZoomEnabled\": \"T" +
            "rue\",\r\n  \"Orthographic\": \"False\",\r\n  \"RotateAroundMouseDownPoint\": \"True\",\r\n  \"S" +
            "howCameraInfo\": \"False\",\r\n  \"ShowCameraTarget\": \"True\",\r\n  \"ShowCoordinateSystem" +
            "\": \"True\",\r\n  \"ShowFrameRate\": \"False\",\r\n  \"ShowTriangleCountInfo\": \"False\",\r\n  " +
            "\"ShowViewCube\": \"True\",\r\n  \"UseDefaultGestures\": \"True\",\r\n  \"IsViewCubeEdgeClick" +
            "sEnabled\": \"False\",\r\n  \"IsViewCubeMoverEnabled\": \"True\",\r\n  \"IsCoordinateSystemM" +
            "overEnabled\": \"True\",\r\n  \"ZoomAroundMouseDownPoint\": \"False\",\r\n  \"ZoomExtentsWhe" +
            "nLoaded\": \"False\",\r\n  \"FixedRotationPointEnabled\": \"False\",\r\n  \"EnableMouseButto" +
            "nHitTest\": \"True\",\r\n  \"EnableDeferredRendering\": \"False\",\r\n  \"EnableSharedModelM" +
            "ode\": \"False\",\r\n  \"EnableSwapChainRendering\": \"True\",\r\n  \"ShowFrameDetails\": \"Fa" +
            "lse\",\r\n  \"EnableD2DRendering\": \"True\",\r\n  \"EnableAutoOctreeUpdate\": \"False\",\r\n  " +
            "\"IsMoveEnabled\": \"True\",\r\n  \"EnableOITRendering\": \"True\",\r\n  \"EnableDesignModeRe" +
            "ndering\": \"False\",\r\n  \"EnableRenderOrder\": \"False\",\r\n  \"EnableSSAO\": \"False\",\r\n " +
            " \"AllowUpDownRotation\": \"True\",\r\n  \"AllowLeftRightRotation\": \"True\",\r\n  \"Belongs" +
            "ToParentWindow\": \"True\",\r\n  \"EnableDpiScale\": \"True\",\r\n  \"IsTabStop\": \"True\",\r\n " +
            " \"OverridesDefaultStyle\": \"False\",\r\n  \"UseLayoutRounding\": \"False\",\r\n  \"ForceCur" +
            "sor\": \"False\",\r\n  \"AllowDrop\": \"False\",\r\n  \"ClipToBounds\": \"False\",\r\n  \"SnapsToD" +
            "evicePixels\": \"False\",\r\n  \"IsEnabled\": \"True\",\r\n  \"IsHitTestVisible\": \"True\",\r\n " +
            " \"Focusable\": \"True\",\r\n  \"IsManipulationEnabled\": \"False\"\r\n}")]
        public string View3DFlags {
            get {
                return ((string)(this["View3DFlags"]));
            }
            set {
                this["View3DFlags"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{\r\n  \"CameraMode\": \"Inspect\",\r\n  \"CameraRotationMode\": \"Trackball\",\r\n  \"MSAA\": \"D" +
            "isable\",\r\n  \"OITWeightMode\": \"Linear1\",\r\n  \"FXAALevel\": \"Medium\",\r\n  \"SSAOQualit" +
            "y\": \"Low\",\r\n  \"FlowDirection\": \"LeftToRight\",\r\n  \"Visibility\": \"Visible\"\r\n}")]
        public string View3DOptions {
            get {
                return ((string)(this["View3DOptions"]));
            }
            set {
                this["View3DOptions"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("File.JSON")]
        public string DataSource {
            get {
                return ((string)(this["DataSource"]));
            }
            set {
                this["DataSource"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoStepOver {
            get {
                return ((bool)(this["AutoStepOver"]));
            }
            set {
                this["AutoStepOver"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DynamicTransition {
            get {
                return ((bool)(this["DynamicTransition"]));
            }
            set {
                this["DynamicTransition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Factor1")]
        public string TimespanFactor {
            get {
                return ((string)(this["TimespanFactor"]));
            }
            set {
                this["TimespanFactor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MaterialRemove {
            get {
                return ((bool)(this["MaterialRemove"]));
            }
            set {
                this["MaterialRemove"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Size5")]
        public string ProbeSize {
            get {
                return ((string)(this["ProbeSize"]));
            }
            set {
                this["ProbeSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Yellow")]
        public string ProbeColor {
            get {
                return ((string)(this["ProbeColor"]));
            }
            set {
                this["ProbeColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Sphere")]
        public string ProbeShape {
            get {
                return ((string)(this["ProbeShape"]));
            }
            set {
                this["ProbeShape"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Sample_20ms")]
        public string MinimumSampleTime {
            get {
                return ((string)(this["MinimumSampleTime"]));
            }
            set {
                this["MinimumSampleTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Orange")]
        public string PanelOuterMaterial {
            get {
                return ((string)(this["PanelOuterMaterial"]));
            }
            set {
                this["PanelOuterMaterial"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Bronze")]
        public string PanelInnerMaterial {
            get {
                return ((string)(this["PanelInnerMaterial"]));
            }
            set {
                this["PanelInnerMaterial"] = value;
            }
        }
    }
}

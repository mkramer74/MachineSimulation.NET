﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Machine.Viewer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("Default")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("{\n  \"EnableCurrentPosition\": \"False\",\n  \"InfiniteSpin\": \"False\",\n  \"IsShadowMappi" +
            "ngEnabled\": \"True\",\n  \"IsChangeFieldOfViewEnabled\": \"True\",\n  \"IsInertiaEnabled\"" +
            ": \"False\",\n  \"IsPanEnabled\": \"True\",\n  \"IsRotationEnabled\": \"True\",\n  \"IsTouchRo" +
            "tateEnabled\": \"True\",\n  \"IsPinchZoomEnabled\": \"True\",\n  \"PinchZoomAtCenter\": \"Fa" +
            "lse\",\n  \"IsThreeFingerPanningEnabled\": \"True\",\n  \"IsZoomEnabled\": \"True\",\n  \"Ort" +
            "hographic\": \"False\",\n  \"RotateAroundMouseDownPoint\": \"True\",\n  \"ShowCameraInfo\":" +
            " \"False\",\n  \"ShowCameraTarget\": \"True\",\n  \"ShowCoordinateSystem\": \"True\",\n  \"Sho" +
            "wFrameRate\": \"False\",\n  \"ShowTriangleCountInfo\": \"False\",\n  \"ShowViewCube\": \"Tru" +
            "e\",\n  \"UseDefaultGestures\": \"True\",\n  \"IsViewCubeEdgeClicksEnabled\": \"False\",\n  " +
            "\"IsViewCubeMoverEnabled\": \"True\",\n  \"IsCoordinateSystemMoverEnabled\": \"True\",\n  " +
            "\"ZoomAroundMouseDownPoint\": \"False\",\n  \"ZoomExtentsWhenLoaded\": \"False\",\n  \"Fixe" +
            "dRotationPointEnabled\": \"False\",\n  \"EnableMouseButtonHitTest\": \"True\",\n  \"Enable" +
            "DeferredRendering\": \"False\",\n  \"EnableSharedModelMode\": \"False\",\n  \"EnableSwapCh" +
            "ainRendering\": \"True\",\n  \"ShowFrameDetails\": \"False\",\n  \"EnableD2DRendering\": \"T" +
            "rue\",\n  \"EnableAutoOctreeUpdate\": \"False\",\n  \"IsMoveEnabled\": \"True\",\n  \"EnableO" +
            "ITRendering\": \"True\",\n  \"EnableDesignModeRendering\": \"False\",\n  \"EnableRenderOrd" +
            "er\": \"False\",\n  \"EnableSSAO\": \"False\",\n  \"AllowUpDownRotation\": \"True\",\n  \"Allow" +
            "LeftRightRotation\": \"True\",\n  \"BelongsToParentWindow\": \"True\",\n  \"EnableDpiScale" +
            "\": \"True\",\n  \"IsTabStop\": \"True\",\n  \"OverridesDefaultStyle\": \"False\",\n  \"UseLayo" +
            "utRounding\": \"False\",\n  \"ForceCursor\": \"False\",\n  \"AllowDrop\": \"False\",\n  \"ClipT" +
            "oBounds\": \"False\",\n  \"SnapsToDevicePixels\": \"False\",\n  \"IsEnabled\": \"True\",\n  \"I" +
            "sHitTestVisible\": \"True\",\n  \"Focusable\": \"True\",\n  \"IsManipulationEnabled\": \"Fal" +
            "se\"\n}")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("{\n  \"CameraMode\": \"Inspect\",\n  \"CameraRotationMode\": \"Trackball\",\n  \"MSAA\": \"Disa" +
            "ble\",\n  \"OITWeightMode\": \"Linear1\",\n  \"FXAALevel\": \"Medium\",\n  \"SSAOQuality\": \"L" +
            "ow\",\n  \"FlowDirection\": \"LeftToRight\",\n  \"Visibility\": \"Visible\"\n}")]
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
    }
}

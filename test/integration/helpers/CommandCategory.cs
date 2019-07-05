using System;

namespace Appium.Net.Integration.Tests.Helpers
{
    /// <summary>
    /// Provides string constants relating the category of each Appium command.
    /// Commands-Category mappings can be determined via the command section on appium.io
    /// </summary>
    public static class CommandCategory
    {
        #region Appium Specific
        public const string Appium_Status = "Status";
        public const string Appium_ExecuteMobileCommand = "Execute_Mobile_Command";
        #endregion Appium Specific

        #region Session
        public const string Session = "Session";
        public const string Session_Timeouts = "Session.Timeouts";
        public const string Session_Orientation = "Session.Orientation";
        public const string Session_Geolocation = "Session.Geolocation";
        public const string Session_Logs = "Session.Logs";
        public const string Session_Settings = "Session.Settings";
        #endregion Session

        #region Device
        public const string Device_Activity = "Device.Activity";
        public const string Device_App = "Device.App";
        public const string Device_Clipboard = "Device.Clipboard";
        public const string Device_Emulator = "Device.Emulator";
        public const string Device_Files = "Device.Files";
        public const string Device_Interactions = "Device.Interactions";
        public const string Device_Keys = "Device.Keys";
        public const string Device_Network = "Device.Network";
        public const string Device_PerformanceData = "Device.Performance_Data";
        public const string Device_ScreenRecording = "Device.Screen_Recording";
        public const string Device_Simulator = "Device.Simulator";
        public const string Device_System = "Device.System";
        public const string Device_Authentication = "Device.Authentication";

        #endregion Device

        #region Element
        public const string Element_FindElement = "Element.Find_Element";
        public const string Element_FindElements = "Element.Find_Elements";
        public const string Element_Actions = "Element.Actions";
        public const string Element_Attributes = "Element.Attributes";
        public const string Element_Other = "Element.Other";
        #endregion Element

        #region Context
        public const string Context = "Context";
        #endregion Context

        #region Interactions
        public const string Interactions_Mouse = "Interactions_Mouse";
        public const string Interactions_Touch = "Interactions_Touch";
        public const string Interactions_W3C_Actions = "Interactions_W3C_Actions";
        #endregion Interactions

        #region Web
        public const string Web = "Web";
        public const string Web_Window = "Web_Window";
        public const string Web_Navigation = "Web_Navigation";
        public const string Web_Storage = "Web_Storage";
        public const string Web_Frame = "Web_Frame";
        #endregion Web
    }
}

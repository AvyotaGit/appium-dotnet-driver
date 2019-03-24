﻿//******************************************************************************
//
// Copyright (c) 2018 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//******************************************************************************

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using Appium.Net.Integration.Tests.Helpers;

namespace Appium.Net.Integration.Tests.Windows
{
    public class StickyNotesTest
    {
        private const string StickyNotesAppId = @"Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe!App";

        protected WindowsDriver<WindowsElement> session;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            // Launch StickyNotes application if it is not yet launched
            if (session == null)
            {
                var serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;

                try
                {
                    // Create a new session to launch or bring up Sticky Notes application
                    // Note: All sticky note windows are parented to Modern_Sticky_Top_Window pane
                    AppiumOptions appCapabilities = new AppiumOptions();
                    appCapabilities.AddAdditionalCapability("app", StickyNotesAppId);
                    appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                    session = new WindowsDriver<WindowsElement>(serverUri, appCapabilities);
                }
                catch
                {
                    // When Sticky Notes application was previously launched, the creation above may fail.
                    // In such failure, simply look for the Modern_Sticky_Top_Window pane using the Desktop
                    // session and create a new session based on the located top window pane.
                    AppiumOptions desktopCapabilities = new AppiumOptions();
                    desktopCapabilities.AddAdditionalCapability("app", "Root");
                    desktopCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                    var desktopSession = new WindowsDriver<WindowsElement>(serverUri, desktopCapabilities);

                    var StickyNotesTopLevelWindow = desktopSession.FindElementByClassName("Modern_Sticky_Top_Window");
                    var StickyNotesTopLevelWindowHandle = StickyNotesTopLevelWindow.GetAttribute("NativeWindowHandle");
                    StickyNotesTopLevelWindowHandle = (int.Parse(StickyNotesTopLevelWindowHandle)).ToString("x"); // Convert to Hex

                    AppiumOptions appCapabilities = new AppiumOptions();
                    appCapabilities.AddAdditionalCapability("appTopLevelWindow", StickyNotesTopLevelWindowHandle);
                    appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                    session = new WindowsDriver<WindowsElement>(serverUri, appCapabilities);
                }
                Assert.IsNotNull(session);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            // Close the application and delete the session
            if (session != null)
            {
                var serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;

                try
                {
                    // Sticky Notes applciation can be closed by explicitly closing any of the opened Sticky Notes window.
                    // Create a new session based on any of opened Sticky Notes window and close it to close the application.
                    var openedStickyNotes = session.FindElementsByClassName("ApplicationFrameWindow");
                    if (openedStickyNotes.Count > 0)
                    {
                        var newStickyNoteWindowHandle = openedStickyNotes[0].GetAttribute("NativeWindowHandle");
                        newStickyNoteWindowHandle = (int.Parse(newStickyNoteWindowHandle)).ToString("x"); // Convert to Hex

                        AppiumOptions appCapabilities = new AppiumOptions();
                        appCapabilities.AddAdditionalCapability("appTopLevelWindow", newStickyNoteWindowHandle);
                        appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                        var stickyNoteSession = new WindowsDriver<WindowsElement>(serverUri, appCapabilities);
                        stickyNoteSession.Close();
                    }
                }
                catch { }

                session.Quit();
                session = null;
            }
        }
    }
}

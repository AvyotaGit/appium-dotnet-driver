﻿using Appium.Net.Integration.Tests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium.Net.Integration.Tests.Android
{
    class HideKeyboardTestCase
    {
        private AndroidDriver<AppiumWebElement> _driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var capabilities = Env.ServerIsRemote()
                ? Caps.GetAndroidCaps(Apps.Get("androidApiDemos"))
                : Caps.GetAndroidCaps(Apps.Get("androidApiDemos"));
            var serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;
            _driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.InitTimeoutSec);
            _driver.Manage().Timeouts().ImplicitWait = Env.ImplicitTimeoutSec;
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            _driver?.Quit();
            if (!Env.ServerIsRemote())
            {
                AppiumServers.StopLocalService();
            }
        }

        [Test]
        public void HideKeyBoardTestCase()
        {
            _driver.StartActivity("io.appium.android.apis", ".app.CustomTitle");
            _driver.FindElement(By.Id("io.appium.android.apis:id/left_text_edit")).Clear();
            _driver.HideKeyboard();
        }
    }
}
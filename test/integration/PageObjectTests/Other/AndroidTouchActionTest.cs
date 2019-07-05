﻿using System;
using Appium.Net.Integration.Tests.Helpers;
using Appium.Net.Integration.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects;
using SeleniumExtras.PageObjects;

namespace Appium.Net.Integration.Tests.PageObjectTests.Other
{
    [TestFixture(Category = CommandCategory.Interactions_Touch)]
    class AndroidTouchActionTest
    {
        private AndroidDriver<AppiumWebElement> _driver;
        private AndroidPageObjectThatChecksTouchActions _pageObject;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var capabilities = Env.ServerIsRemote()
                ? Caps.GetAndroidCaps(Apps.Get("androidApiDemos"))
                : Caps.GetAndroidCaps(Apps.Get("androidApiDemos"));
            var serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;
            _driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.InitTimeoutSec);
            var timeSpan = new TimeOutDuration(new TimeSpan(0, 0, 0, 5, 0));
            _pageObject = new AndroidPageObjectThatChecksTouchActions();
            PageFactory.InitElements(_driver, _pageObject, new AppiumPageObjectMemberDecorator(timeSpan));
        }

        [OneTimeTearDown]
        public void AfterEach()
        {
            _driver?.Quit();
            if (!Env.ServerIsRemote())
            {
                AppiumServers.StopLocalService();
            }
        }

        [Test]
        public void CheckTap()
        {
            _pageObject.CheckTap(_driver);
        }
    }
}
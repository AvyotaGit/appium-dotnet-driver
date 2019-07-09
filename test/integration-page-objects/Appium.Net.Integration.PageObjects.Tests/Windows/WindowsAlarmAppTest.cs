using System;
using Appium.Net.Integration.PageObjects.Tests.PageObjects;
using Appium.Net.Integration.Tests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Appium.Windows;

namespace Appium.Net.Integration.PageObjects.Tests.Windows
{
    [TestFixture(Category = CommandCategory.Element_FindElement)]
    [Category(CommandCategory.Element_FindElements)]
    public class WindowsAlarmAppTest
    {
        private AppiumDriver<AppiumWebElement> _driver;

        [SetUp]
        public void Setup()
        {
            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
            appCapabilities.AddAdditionalCapability("platformName", "Windows");
            appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");

            var serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;

            _driver = new WindowsDriver<AppiumWebElement>(serverUri, appCapabilities);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.CloseApp();
        }

        [Test]
        public void AddAlarm()
        { 
            var alarmApp = new WindowsAlarmApp(_driver, new TimeOutDuration(TimeSpan.FromSeconds(2)));

            //alarmApp.SwitchToClockTab();
            var localTimeText = alarmApp.LocalTime;

            alarmApp.SwitchToAlarmTab();

            var alarmName = "Windows Page Object Alarm";
            alarmApp.AddAlarmOffsetByOneMinute(localTimeText, alarmName);

            Assert.IsTrue(alarmApp.HasAlarmWithName(alarmName));

            alarmApp.DeleteAlarmWithName(alarmName);
        }
    }
}

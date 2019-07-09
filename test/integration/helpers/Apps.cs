using System;
using System.Collections.Generic;
using System.IO;
using Appium.Net.Integration.Tests.Properties;

namespace Appium.Net.Integration.Tests.Helpers
{
    public class Apps
    {
        private static bool _isInited;
        private static Dictionary<string, string> _testApps;
        private const string ApiDemos_debugQualifiedName = "Appium.Net.Integration.Tests.Apps.ApiDemos-debug.apk";
        private const string TestApp_appQualifiedName = "Appium.Net.Integration.Tests.Apps.TestApp.app.zip";
        private const string WebViewApp_appQualifiedName = "Appium.Net.Integration.Tests.Apps.WebViewApp.app.zip";
        private const string UICatalog_appQualifiedName = "Appium.Net.Integration.Tests.Apps.UICatalog.app.zip";
        private const string IntentExampleQualifiedName = "Appium.Net.Integration.Tests.Apps.IntentExample.apk";
        private const string vodqaQualifiedName = "Appium.Net.Integration.Tests.Apps.vodqa.app.zip";

        private static string _testAppsDir = $"{AppDomain.CurrentDomain.BaseDirectory}..//..//..//apps";

        private static void Init()
        {
            if (!_isInited)
            {
                if (Env.ServerIsRemote())
                {
                    _testApps = new Dictionary<string, string>
                    {
                        {"iosTestApp", "https://github.com/appium/appium-dotnet-driver/blob/master/test/integration/apps/archives/TestApp.app.zip?raw=true"},
                        {"intentApp", "https://github.com/appium/appium-dotnet-driver/blob/master/test/integration/apps/archives/IntentExample.zip?raw=true"},
                        {"iosWebviewApp", "https://github.com/appium/appium-dotnet-driver/blob/master/test/integration/apps/archives/WebViewApp.app.zip?raw=true"},
                        {"iosUICatalogApp", "https://github.com/appium/appium-dotnet-driver/blob/master/test/integration/apps/archives/UICatalog.app.zip?raw=true"},
                        {"androidApiDemos", "https://github.com/appium/appium-dotnet-driver/blob/master/test/integration/apps/archives/ApiDemos-debug.zip?raw=true"},
                        {"vodqaApp", "https://github.com/appium/appium-dotnet-driver/blob/master/test/integration/apps/archives/vodqa.zip?raw=true"}
                    };
                }
                else
                {
                    var tempFolder = $"{Path.GetTempPath()}/AppiumTestApps";
                    if (!Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);

                    Console.WriteLine("Passed in name" + ApiDemos_debugQualifiedName);
                    File.WriteAllBytes($"{tempFolder}/ApiDemos-debug.apk", ResourceHelper.GetBytes<Resources>(ApiDemos_debugQualifiedName));
                    File.WriteAllBytes($"{tempFolder}/TestApp.app.zip", ResourceHelper.GetBytes<Resources>(TestApp_appQualifiedName));
                    File.WriteAllBytes($"{tempFolder}/WebViewApp.app.zip", ResourceHelper.GetBytes<Resources>(WebViewApp_appQualifiedName));
                    File.WriteAllBytes($"{tempFolder}/UICatalog.app.zip", ResourceHelper.GetBytes<Resources>(UICatalog_appQualifiedName));
                    File.WriteAllBytes($"{tempFolder}/IntentExample.apk", ResourceHelper.GetBytes<Resources>(IntentExampleQualifiedName));
                    File.WriteAllBytes($"{tempFolder}/vodqa.app.zip", ResourceHelper.GetBytes<Resources>(vodqaQualifiedName));

                    _testApps = new Dictionary<string, string>
                    {
                        {"iosTestApp", new FileInfo($"{Path.GetTempPath()}/TestApp.app.zip").FullName},
                        {"intentApp", new FileInfo($"{Path.GetTempPath()}/IntentExample.apk").FullName},
                        {"iosWebviewApp", new FileInfo($"{Path.GetTempPath()}//WebViewApp.app.zip").FullName},
                        {"iosUICatalogApp", new FileInfo($"{Path.GetTempPath()}/UICatalog.app.zip").FullName},
                        {"androidApiDemos", new FileInfo($"{Path.GetTempPath()}/ApiDemos-debug.apk").FullName},
                        {"vodqaApp", new FileInfo($"{Path.GetTempPath()}/vodqa.app.zip").FullName}

                    };
                }
                _isInited = true;
            }
        }

        public static string Get(string appKey)
        {
            Init();
            return _testApps[appKey];
        }
    }
}
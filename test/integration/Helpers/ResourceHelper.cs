using System;
using System.IO;
namespace Appium.Net.Integration.Tests.Helpers
{
    public static class ResourceHelper
    {
        public static byte[] GetBytes<T>(string name)
        {
            var assembly = typeof(T).Assembly;
            using (var stream = assembly.GetManifestResourceStream(name))
            {
                
                if (stream == null)
                {
                    Console.WriteLine("Actual name: " + name);
                    throw new Exception(
                        $"Resource {name} not found in {assembly.FullName}. \nValid resources are: {string.Join(", ", assembly.GetManifestResourceNames())}.");
                }
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}

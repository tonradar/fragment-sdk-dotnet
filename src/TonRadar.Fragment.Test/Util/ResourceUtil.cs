using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TonRadar.Fragment.Test.Util
{
    internal static class ResourceUtil
    {
        public static async Task<string> LoadResourceAsync(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            await using var stream = assembly.GetManifestResourceStream(resourceName);

            if (stream == null)
                throw new InvalidOperationException($"Resource can not found: {resourceName}");

            using var reader = new StreamReader(stream);
            string result = await reader.ReadToEndAsync();
            return result;
        }
    }
}

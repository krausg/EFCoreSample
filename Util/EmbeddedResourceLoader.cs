using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EFCoreSample.Util
{
    public class EmbeddedResourceLoader
    {
        public static string ReadFullContent(string ns, string res)
        {
            var projectName = Assembly.GetCallingAssembly().GetName().Name;
            using (var reader = new StreamReader(Assembly.LoadFrom(projectName).GetManifestResourceStream(string.Format("{0}.{1}.{2}", projectName, ns, res))))
                return reader.ReadToEnd();

        }
    }
}

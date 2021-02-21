using System.IO;
using System.Reflection;

namespace EFCoreSample.Util.Resource
{
    public class EmbeddedResourceLoader
    {
        public static string ReadFullContent(string ns, string res)
        {
            var projectName = Assembly.GetCallingAssembly().GetName().Name;
            var loadedAssembly = Assembly.LoadFrom(projectName.Contains(".") ? projectName + ".dll" : projectName);
            using (var reader = new StreamReader(loadedAssembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", projectName, ns, res))))
                return reader.ReadToEnd();

        }
    }
}

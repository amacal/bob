using System.IO;
using System.Linq;

using Bob.Core;

namespace Bob.Extensions.NuGet
{
    public class NuGetAppDataCache : NuGetCache
    {
        public string Resolve()
        {
            Glob pattern = Glob.Parse("cache\\nuget\\nuget.exe");

            return Container.Storage.Data.Files(pattern).SingleOrDefault();
        }

        public void Apply(string path)
        {
            string destination = Path.Combine(Container.Storage.Data.Path, "cache", "nuget", "nuget.exe");

            Container.Storage.WriteBytes(destination, Container.Storage.ReadBytes(path));
        }
    }
}

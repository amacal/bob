using System.IO;

using Bob.Core;

namespace Bob.Extensions.NuGet
{
    public class NuGetOnlinePath : NuGetPath
    {
        public string Resolve()
        {
            byte[] data = Container.Network.Get("http://nuget.org/nuget.exe");
            string path = Path.Combine(Container.Storage.Temp.Path, "nuget.exe");

            Container.Storage.Write(path, data);

            return path;
        }
    }
}

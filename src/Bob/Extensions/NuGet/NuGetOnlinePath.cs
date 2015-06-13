using System;
using System.IO;

using Bob.Core;

namespace Bob.Extensions.NuGet
{
    public class NuGetOnlinePath : NuGetPath
    {
        private readonly Action<NuGetOnlineParameters> parameters;

        public NuGetOnlinePath()
        {
        }

        public NuGetOnlinePath(Action<NuGetOnlineParameters> parameters)
        {
            this.parameters = parameters;
        }

        public string Resolve()
        {
            NuGetOnlineParameters instance = new NuGetOnlineParameters
            {
                Cache = Bob.NuGet.Cache.Default()
            };

            if (this.parameters != null)
            {
                this.parameters(instance);
            }

            return this.Resolve(instance);
        }

        private string Resolve(NuGetOnlineParameters parameters)
        {
            string path = parameters.Cache.Resolve();

            if (path == null)
            {
                byte[] data = Container.Network.Get("http://nuget.org/nuget.exe");
                path = Path.Combine(Container.Storage.Temp.Path, "nuget.exe");

                Container.Storage.WriteBytes(path, data);
                parameters.Cache.Apply(path);
            }

            return path;
        }
    }
}

using System;

namespace Bob.Extensions.NuGet
{
    public class NuGetPathRepository
    {
        public NuGetPath Default()
        {
            return new NuGetDefaultPath();
        }

        public NuGetPath Online()
        {
            return new NuGetOnlinePath();
        }

        public NuGetPath Online(Action<NuGetOnlineParameters> parameters)
        {
            return new NuGetOnlinePath(parameters);
        }
    }
}
using System;

using Bob.Extensions.NuGet;

namespace Bob
{
    public static class NuGet
    {
        public static NuGetPathRepository Path
        {
            get { return new NuGetPathRepository(); }
        }

        public static NuGetPackageRepository Repository
        {
            get { return new NuGetPackageRepository(); }
        }

        public static ITask Install(Action<NuGetInstallParameters> parameters)
        {
            return NuGetCommands.Install().Execute(parameters);
        }

        public static ITask Restore(Action<NuGetRestoreParameters> parameters)
        {
            return NuGetCommands.Restore().Execute(parameters);
        }
    }
}

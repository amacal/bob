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

        public static ITask Restore(Action<NuGetRestoreParameters> parameters)
        {
            return NuGetCommands.Restore().Execute(parameters);
        }
    }
}

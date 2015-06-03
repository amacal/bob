using System;

namespace Bob.Extensions.NuGet
{
    public class NuGetRestoreCommand
    {
        public ITask Execute()
        {
            return new NuGetRestoreTask(() =>
            {
                NuGetRestoreParameters instance = new NuGetRestoreParameters
                {
                    Path = Bob.NuGet.Path.Default()
                };

                return instance;
            });
        }

        public ITask Execute(Action<NuGetRestoreParameters> parameters)
        {
            return new NuGetRestoreTask(() =>
            {
                NuGetRestoreParameters instance = new NuGetRestoreParameters
                {
                    Path = Bob.NuGet.Path.Default()
                };

                parameters(instance);
                return instance;
            });
        }
    }
}

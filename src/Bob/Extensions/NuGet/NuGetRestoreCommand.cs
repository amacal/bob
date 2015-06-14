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
                    Path = NuGetConfiguration.Instance.Path
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
                    Path = NuGetConfiguration.Instance.Path
                };

                parameters(instance);
                return instance;
            });
        }
    }
}
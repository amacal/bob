using System;

namespace Bob.Extensions.NuGet
{
    public class NuGetInstallCommand
    {
        public ITask Execute(Action<NuGetInstallParameters> parameters)
        {
            return new NuGetInstallTask(() =>
            {
                NuGetInstallParameters instance = new NuGetInstallParameters
                {
                    Path = NuGetConfiguration.Instance.Path,
                    Output = Bob.FileSystem.Directories.Relative("packages")
                };

                parameters(instance);
                return instance;
            });
        }
    }
}
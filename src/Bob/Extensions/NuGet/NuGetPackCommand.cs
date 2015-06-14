using System;

namespace Bob.Extensions.NuGet
{
    public class NuGetPackCommand
    {
        public ITask Execute(Action<NuGetPackParameters> parameters)
        {
            return new NuGetPackTask(() =>
            {
                NuGetPackParameters instance = new NuGetPackParameters
                {
                    Path = NuGetConfiguration.Instance.Path
                };

                parameters(instance);
                return instance;
            });
        }
    }
}
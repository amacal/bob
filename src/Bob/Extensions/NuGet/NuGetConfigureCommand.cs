using System;

namespace Bob.Extensions.NuGet
{
    public class NuGetConfigureCommand
    {
        public ITask Execute(Action<NuGetConfigureParameters> parameters)
        {
            return new NuGetConfigureTask(() =>
            {
                NuGetConfigureParameters instance = new NuGetConfigureParameters
                {
                    Path = NuGetConfiguration.Instance.Path
                };

                parameters(instance);
                return instance;
            });
        }
    }
}

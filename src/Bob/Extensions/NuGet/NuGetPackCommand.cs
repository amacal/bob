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
                    Path = Bob.NuGet.Path.Default()
                };

                parameters(instance);
                return instance;
            });
        }
    }
}

using System;

namespace Bob.Extensions.NuGet
{
    public class NuGetSpecificationRepository
    {
        public NuGetSpecification Template(string pattern)
        {
            return new NuGetMatchSpecification(pattern);
        }

        public NuGetSpecification Inline(Action<NuGetInlineParameters> parameters)
        {
            return new NuGetInlineSpecification(parameters);
        }
    }
}

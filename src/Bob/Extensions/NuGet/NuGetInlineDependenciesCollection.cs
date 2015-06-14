using System.Collections.Generic;

namespace Bob.Extensions.NuGet
{
    public class NuGetInlineDependenciesCollection
    {
        private readonly List<NuGetPackage> packages;

        public NuGetInlineDependenciesCollection()
        {
            this.packages = new List<NuGetPackage>();
        }

        public void Add(string name, string version)
        {
            this.packages.Add(new NuGetPackage(name, version));
        }

        public IEnumerable<NuGetPackage> Packages
        {
            get { return this.packages; }
        }
    }
}
using System.Linq;

namespace Bob.Extensions.NuGet
{
    public class NuGetMatchSpecification : NuGetSpecification
    {
        private readonly string pattern;

        public NuGetMatchSpecification(string pattern)
        {
            this.pattern = pattern;
        }

        public string Resolve()
        {
            return Bob.FileSystem.Files.Match(this.pattern).Execute().Single();
        }
    }
}
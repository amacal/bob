using System.Linq;

namespace Bob.Extensions.NUnit
{
    public class NUnitPackagePath : NUnitPath
    {
        public string Resolve()
        {
            return Bob.FileSystem.Files.Match(@"**\NUnit.Runners.*\tools\nunit-console.exe").Execute().Single();
        }
    }
}

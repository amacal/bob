using System.Linq;

namespace Bob.Extensions.NuGet
{
    public class NuGetDefaultPath : NuGetPath
    {
        public string Resolve()
        {
            return Bob.FileSystem.Files.Match(@".nuget\nuget.exe").Execute().Single();
        }
    }
}
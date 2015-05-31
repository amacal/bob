using System.Linq;

namespace Bob.Extensions.ILRepack
{
    public class ILRepackPackagePath : ILRepackPath
    {
        public string Resolve()
        {
            return Bob.FileSystem.Files.Match(@"**\ilrepack.*\tools\ilrepack.exe").Execute().Single();
        }
    }
}

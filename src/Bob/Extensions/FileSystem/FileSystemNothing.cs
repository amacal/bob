using System.Collections.Generic;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemNothing : IFileSystemItem
    {
        public IEnumerable<string> Execute()
        {
            yield break;
        }
    }
}

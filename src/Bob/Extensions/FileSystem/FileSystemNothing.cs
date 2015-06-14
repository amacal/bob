using System.Collections.Generic;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemNothing : FileSystemItem
    {
        public IEnumerable<string> Execute()
        {
            yield break;
        }
    }
}
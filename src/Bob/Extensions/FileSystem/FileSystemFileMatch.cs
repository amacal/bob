using System.Collections.Generic;

using Bob.Core;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemFileMatch : FileSystemItem
    {
        private readonly Glob glob;

        public FileSystemFileMatch(string pattern)
        {
            this.glob = Glob.Parse(pattern);
        }

        public IEnumerable<string> Execute()
        {
            return Container.Storage.Local.Files(this.glob);
        }
    }
}

using System.Collections.Generic;

using Bob.Core;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemDirectoryMatch : FileSystemItem
    {
        private readonly Glob glob;

        public FileSystemDirectoryMatch(string pattern)
        {
            this.glob = Glob.Parse(pattern);
        }

        public IEnumerable<string> Execute()
        {
            return Container.Storage.Local.Directories(this.glob);
        }
    }
}

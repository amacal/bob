using Bob.Core;
using System.Collections.Generic;
using System.IO;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemRelative : IFileSystemItem
    {
        private readonly string path;

        public FileSystemRelative(string path)
        {
            this.path = path;
        }

        public IEnumerable<string> Execute()
        {
            yield return Path.Combine(Container.Storage.Local.Path, this.path).Backslash();
        }
    }
}

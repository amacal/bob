using System.Collections.Generic;
using System.Linq;

using Bob.Core;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemFileMatch : FileSystemItem
    {
        private readonly Glob[] globs;

        public FileSystemFileMatch(string[] patterns)
        {
            this.globs = patterns.Select(Glob.Parse).ToArray();
        }

        public IEnumerable<string> Execute()
        {
            HashSet<string> results = new HashSet<string>();

            foreach (Glob glob in this.globs)
            {
                foreach (string result in Container.Storage.Local.Files(glob))
                {
                    results.Add(result);
                }
            }

            return results.OrderBy(x => x);
        }
    }
}

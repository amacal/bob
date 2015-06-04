using System.Collections.Generic;

namespace Bob.Extensions.NuGet
{
    public class NuGetInlineFilesCollection
    {
        private readonly Dictionary<string, FileSystemItem> items;

        public NuGetInlineFilesCollection()
        {
            this.items = new Dictionary<string, FileSystemItem>();
        }

        public IEnumerable<string> Targets
        {
            get { return this.items.Keys; }
        }

        public FileSystemItem this[string target]
        {
            get { return this.items[target]; }
            set { this.items[target] = value; }
        }
    }
}

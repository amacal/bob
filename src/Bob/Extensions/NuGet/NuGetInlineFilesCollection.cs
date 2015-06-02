using System.Collections.Generic;

namespace Bob.Extensions.NuGet
{
    public class NuGetInlineFilesCollection
    {
        private readonly Dictionary<string, IFileSystemItem> items;

        public NuGetInlineFilesCollection()
        {
            this.items = new Dictionary<string, IFileSystemItem>();
        }

        public IEnumerable<string> Targets
        {
            get { return this.items.Keys; }
        }

        public IFileSystemItem this[string target]
        {
            get { return this.items[target]; }
            set { this.items[target] = value; }
        }
    }
}

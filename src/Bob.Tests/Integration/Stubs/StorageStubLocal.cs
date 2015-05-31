using System.Collections.Generic;

using Bob.Core;

namespace Bob.Tests.Integration.Stubs
{
    public class StorageStubLocal : IStorageLocal
    {
        private readonly string path;
        private readonly ICollection<FileSystemTree> trees;

        public StorageStubLocal(string path, ICollection<FileSystemTree> trees)
        {
            this.path = path;
            this.trees = trees;
        }

        public string Path
        {
            get { return this.path; }
        }

        public IEnumerable<string> Files(Glob glob)
        {
            FileSystemFilesVisitor visitor = new FileSystemFilesVisitor(this.path, glob);

            foreach (FileSystemTree tree in this.trees)
            {
                tree.Accept(visitor);
            }

            return visitor.GetFiles();
        }

        public IEnumerable<string> Directories(Glob glob)
        {
            yield break;
        }
    }
}

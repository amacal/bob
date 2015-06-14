using Bob.Core;
using System.Collections.Generic;

namespace Bob.Tests.Integration.Stubs
{
    public class StorageStubData : IStorageData
    {
        private readonly string path;
        private readonly ICollection<FileSystemTree> trees;

        public StorageStubData(string path, ICollection<FileSystemTree> trees)
        {
            this.path = path;
            this.trees = trees;
        }

        public string Path
        {
            get { return this.path; }
        }

        public IEnumerable<string> Files(Glob pattern)
        {
            FileSystemFilesVisitor visitor = new FileSystemFilesVisitor(this.path, pattern);

            foreach (FileSystemTree tree in this.trees)
            {
                tree.Accept(visitor);
            }

            return visitor.GetFiles();
        }
    }
}
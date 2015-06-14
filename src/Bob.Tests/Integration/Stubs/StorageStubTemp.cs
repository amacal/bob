using Bob.Core;
using System.Collections.Generic;

namespace Bob.Tests.Integration.Stubs
{
    public class StorageStubTemp : IStorageTemp
    {
        private readonly string path;
        private readonly ICollection<FileSystemTree> trees;

        public StorageStubTemp(string path, ICollection<FileSystemTree> trees)
        {
            this.path = path;
            this.trees = trees;
        }

        public string Path
        {
            get { return this.path; }
        }

        public string New(string extension)
        {
            return System.IO.Path.Combine(this.path, System.IO.Path.ChangeExtension("file.tmp", extension));
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
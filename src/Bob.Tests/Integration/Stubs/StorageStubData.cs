using System.Collections.Generic;

using Bob.Core;

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
    }
}

using System.Collections.Generic;

using Bob.Core;

namespace Bob.Tests.Integration.Stubs
{
    public class StorageStub : IStorage
    {
        private readonly ICollection<FileSystemTree> trees;

        private StorageStubLocal local;
        private StorageStubTemp temp;
        private StorageStubData data;

        public StorageStub()
        {
            this.trees = new List<FileSystemTree>();
            this.local = new StorageStubLocal(@"c:\Users\Develop", this.trees);
            this.temp = new StorageStubTemp(@"c:\Users\Temp", this.trees);
            this.data = new StorageStubData(@"c:\Users\Data", this.trees);
        }

        public IStorageLocal Local
        {
            get { return this.local; }
        }

        public IStorageTemp Temp
        {
            get { return this.temp; }
        }

        public IStorageData Data
        {
            get { return this.data; }
        }

        public void NewDirectory(string path)
        {
            this.trees.Add(new FileSystemTree(path));
        }

        public void WriteBytes(string path, byte[] data)
        {
        }

        public void WriteText(string path, string data)
        {
        }

        public byte[] ReadBytes(string path)
        {
            return new byte[0];
        }

        public void SetWorkingDirectory(string path)
        {
            this.local = new StorageStubLocal(path.Backslash(), this.trees);
        }

        public void SetTempDirectory(string path)
        {
            this.temp = new StorageStubTemp(path.Backslash(), this.trees);
        }

        public void Register(FileSystemTree tree)
        {
            this.trees.Add(tree);
        }

        public void DeleteFile(string path)
        {
        }

        public void DeleteDirectory(string path)
        {
        }
    }
}

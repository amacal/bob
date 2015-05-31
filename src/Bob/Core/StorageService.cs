using System;
using System.IO;

namespace Bob.Core
{
    public class StorageService : IStorage
    {
        private readonly IStorageLocal local;
        private readonly IStorageTemp temp;

        public StorageService()
        {
            this.local = new StorageServiceLocal(Environment.CurrentDirectory);
            this.temp = new StorageServiceTemp(Path.GetTempPath());
        }

        public IStorageLocal Local
        {
            get { return this.local; }
        }

        public IStorageTemp Temp
        {
            get { return this.temp; }
        }

        public void NewDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void WriteFile(string path, byte[] data)
        {
            File.WriteAllBytes(path, data);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }
    }
}

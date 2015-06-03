using System;
using System.IO;

namespace Bob.Core
{
    public class StorageService : IStorage
    {
        private readonly IStorageLocal local;
        private readonly IStorageTemp temp;
        private readonly IStorageData data;

        public StorageService()
        {
            this.local = new StorageServiceLocal(Environment.CurrentDirectory);
            this.temp = new StorageServiceTemp(Path.GetTempPath());
            this.data = new StorageServiceData(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
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
            Directory.CreateDirectory(path);
        }

        public void Write(string path, byte[] data)
        {
            File.WriteAllBytes(path, data);
        }

        public void Write(string path, string data)
        {
            File.WriteAllText(path, data);
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

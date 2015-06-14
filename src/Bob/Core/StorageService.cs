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
            this.data = new StorageServiceData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "adma", "bob"));
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

        public void WriteBytes(string path, byte[] data)
        {
            string directory = Path.GetDirectoryName(path);

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllBytes(path, data);
        }

        public void WriteText(string path, string data)
        {
            string directory = Path.GetDirectoryName(path);

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(path, data);
        }

        public byte[] ReadBytes(string path)
        {
            return File.ReadAllBytes(path);
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
using System.Collections.Generic;

namespace Bob.Core
{
    public interface IStorage
    {
        IStorageLocal Local { get; }

        IStorageTemp Temp { get; }

        IStorageData Data { get; }

        void NewDirectory(string path);

        void WriteBytes(string path, byte[] data);

        void WriteText(string path, string data);

        byte[] ReadBytes(string path);

        void DeleteFile(string path);

        void DeleteDirectory(string path);
    }
}

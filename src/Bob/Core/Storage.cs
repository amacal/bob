using System.Collections.Generic;

namespace Bob.Core
{
    public interface IStorage
    {
        IStorageLocal Local { get; }

        IStorageTemp Temp { get; }

        void NewDirectory(string path);

        void Write(string path, byte[] data);

        void Write(string path, string data);

        void DeleteFile(string path);

        void DeleteDirectory(string path);
    }
}

using System.Collections.Generic;

namespace Bob.Core
{
    public interface IStorage
    {
        IStorageLocal Local { get; }

        IStorageTemp Temp { get; }

        void NewDirectory(string path);

        void WriteFile(string path, byte[] data);

        void DeleteFile(string path);

        void DeleteDirectory(string path);
    }
}

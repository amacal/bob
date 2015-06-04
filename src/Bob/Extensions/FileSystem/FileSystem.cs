using System;

using Bob.Extensions;
using Bob.Extensions.FileSystem;

namespace Bob
{
    public static class FileSystem
    {
        public static FileSystemFileRepository Files
        {
            get { return new FileSystemFileRepository(); }
        }

        public static FileSystemDirectoryRepository Directories
        {
            get { return new FileSystemDirectoryRepository(); }
        }

        public static FileSystemItem Nothing()
        {
            return new FileSystemNothing();
        }

        public static ITask Delete(Action<FileSystemDeleteParameters> parameters)
        {
            return FileSystemCommands.Delete().Execute(parameters);
        }

        public static ITask NewDirectory(Action<FileSystemNewDirectoryParameters> parameters)
        {
            return FileSystemCommands.NewDirectory().Execute(parameters);
        }
    }
}

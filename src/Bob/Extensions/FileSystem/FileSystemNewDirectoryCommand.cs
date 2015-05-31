using System;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemNewDirectoryCommand
    {
        public ITask Execute(Action<FileSystemNewDirectoryParameters> parameters)
        {
            return new FileSystemNewDirectoryTask(() =>
            {
                FileSystemNewDirectoryParameters instance = new FileSystemNewDirectoryParameters
                {
                };

                parameters(instance);
                return instance;
            });
        }
    }
}

using System;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemDeleteCommand
    {
        public ITask Execute(Action<FileSystemDeleteParameters> parameters)
        {
            return new FileSystemDeleteTask(() =>
            {
                FileSystemDeleteParameters instance = new FileSystemDeleteParameters
                {
                };

                parameters(instance);
                return instance;
            });
        }
    }
}
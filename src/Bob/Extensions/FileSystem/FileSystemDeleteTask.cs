using Bob.Core;
using System;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemDeleteTask : ITask
    {
        private readonly Func<FileSystemDeleteParameters> parameters;

        public FileSystemDeleteTask(Func<FileSystemDeleteParameters> parameters)
        {
            this.parameters = parameters;
        }

        public void Execute()
        {
            this.Execute(this.parameters());
        }

        private void Execute(FileSystemDeleteParameters data)
        {
            if (data.Files != null)
            {
                foreach (string path in data.Files.Execute())
                {
                    Container.Storage.DeleteFile(path);
                }
            }

            if (data.Directories != null)
            {
                foreach (string path in data.Directories.Execute())
                {
                    Container.Storage.DeleteDirectory(path);
                }
            }
        }
    }
}

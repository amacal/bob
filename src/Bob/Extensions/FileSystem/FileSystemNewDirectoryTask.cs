using System;

using Bob.Core;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemNewDirectoryTask : ITask
    {
        private readonly Func<FileSystemNewDirectoryParameters> parameters;

        public FileSystemNewDirectoryTask(Func<FileSystemNewDirectoryParameters> parameters)
        {
            this.parameters = parameters;
        }

        public void Execute()
        {
            this.Execute(this.parameters());
        }

        private void Execute(FileSystemNewDirectoryParameters data)
        {
            foreach (string path in data.Path.Execute())
            {
                Container.Storage.NewDirectory(path);
            }
        }
    }
}

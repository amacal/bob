using System;

using Bob.Core;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemDeleteTask : ITask
    {
        private readonly Func<FileSystemDeleteParameters> parameters;

        public FileSystemDeleteTask(Func<FileSystemDeleteParameters> parameters)
        {
            this.parameters = parameters;
        }

        public TaskResult Execute()
        {
            return this.Execute(this.parameters());
        }

        private TaskResult Execute(FileSystemDeleteParameters data)
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

            return TaskResult.Successful;
        }
    }
}

using Bob.Core;
using System;

namespace Bob.Extensions.FileSystem
{
    public class FileSystemNewDirectoryTask : ITask
    {
        private readonly Func<FileSystemNewDirectoryParameters> parameters;

        public FileSystemNewDirectoryTask(Func<FileSystemNewDirectoryParameters> parameters)
        {
            this.parameters = parameters;
        }

        public TaskResult Execute()
        {
            return this.Execute(this.parameters());
        }

        private TaskResult Execute(FileSystemNewDirectoryParameters data)
        {
            foreach (string path in data.Path.Execute())
            {
                Container.Storage.NewDirectory(path);
            }

            return TaskResult.Successful;
        }
    }
}
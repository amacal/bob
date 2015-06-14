namespace Bob.Extensions.FileSystem
{
    public static class FileSystemCommands
    {
        public static FileSystemDeleteCommand Delete()
        {
            return new FileSystemDeleteCommand();
        }

        public static FileSystemNewDirectoryCommand NewDirectory()
        {
            return new FileSystemNewDirectoryCommand();
        }
    }
}
namespace Bob.Extensions.FileSystem
{
    public class FileSystemFileRepository
    {
        public IFileSystemItem Relative(string path)
        {
            return new FileSystemRelative(path);
        }

        public IFileSystemItem Match(string pattern)
        {
            return new FileSystemFileMatch(pattern);
        }
    }
}

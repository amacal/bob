namespace Bob.Extensions.FileSystem
{
    public class FileSystemDirectoryRepository
    {
        public IFileSystemItem Relative(string path)
        {
            return new FileSystemRelative(path);
        }

        public IFileSystemItem Match(string pattern)
        {
            return new FileSystemDirectoryMatch(pattern);
        }
    }
}

namespace Bob.Extensions.FileSystem
{
    public class FileSystemDirectoryRepository
    {
        public FileSystemItem Relative(string path)
        {
            return new FileSystemRelative(path);
        }

        public FileSystemItem Match(string pattern)
        {
            return new FileSystemDirectoryMatch(pattern);
        }
    }
}

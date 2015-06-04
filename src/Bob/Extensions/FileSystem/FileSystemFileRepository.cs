namespace Bob.Extensions.FileSystem
{
    public class FileSystemFileRepository
    {
        public FileSystemItem Relative(string path)
        {
            return new FileSystemRelative(path);
        }

        public FileSystemItem Match(string pattern)
        {
            return new FileSystemFileMatch(pattern);
        }
    }
}

namespace Bob.Extensions.FileSystem
{
    public class FileSystemFileRepository
    {
        public FileSystemItem Relative(string path)
        {
            return new FileSystemRelative(path);
        }

        public FileSystemItem Match(params string[] patterns)
        {
            return new FileSystemFileMatch(patterns);
        }
    }
}

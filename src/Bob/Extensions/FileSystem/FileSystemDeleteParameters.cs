namespace Bob.Extensions.FileSystem
{
    public class FileSystemDeleteParameters
    {
        public IFileSystemItem Files { get; set; }

        public IFileSystemItem Directories { get; set; }
    }
}

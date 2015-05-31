namespace Bob.Extensions.MsBuild
{
    public class MsBuildCompileParameters
    {
        public IFileSystemItem Solution { get; set; }

        public IFileSystemItem Output { get; set; }
    }
}

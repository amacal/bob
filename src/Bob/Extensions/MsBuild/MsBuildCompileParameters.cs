namespace Bob.Extensions.MsBuild
{
    public class MsBuildCompileParameters
    {
        public FileSystemItem Solution { get; set; }

        public FileSystemItem Output { get; set; }

        public MsBuildPropertyCollection Properties { get; set; }
    }
}

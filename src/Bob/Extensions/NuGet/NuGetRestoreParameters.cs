namespace Bob.Extensions.NuGet
{
    public class NuGetRestoreParameters
    {
        public NuGetPath Path { get; set; }

        public FileSystemItem Solution { get; set; }
    }
}
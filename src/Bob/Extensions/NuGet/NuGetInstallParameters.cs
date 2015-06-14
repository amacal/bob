namespace Bob.Extensions.NuGet
{
    public class NuGetInstallParameters
    {
        public NuGetPath Path { get; set; }

        public FileSystemItem Output { get; set; }

        public NuGetPackage Package { get; set; }
    }
}
namespace Bob.Extensions.NuGet
{
    public class NuGetPackParameters
    {
        public NuGetPath Path { get; set; }

        public FileSystemItem Output { get; set; }

        public NuGetSpecification Specification { get; set; }
    }
}

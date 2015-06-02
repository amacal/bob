namespace Bob.Extensions.NuGet
{
    public class NuGetInlineParameters
    {
        public string Id { get; set; }

        public string Version { get; set; }

        public string Authors { get; set; }

        public string Description { get; set; }

        public NuGetInlineFilesCollection Files { get; set; }
    }
}

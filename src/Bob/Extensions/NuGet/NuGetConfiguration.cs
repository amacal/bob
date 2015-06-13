namespace Bob.Extensions.NuGet
{
    public class NuGetConfiguration
    {
        public static readonly NuGetConfiguration Instance;

        static NuGetConfiguration()
        {
            NuGetConfiguration.Instance = new NuGetConfiguration
            {
                Path = Bob.NuGet.Path.Default()
            };
        }

        private NuGetConfiguration()
        {
        }

        public NuGetPath Path { get; internal set; }
    }
}

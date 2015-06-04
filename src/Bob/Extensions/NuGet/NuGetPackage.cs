namespace Bob.Extensions.NuGet
{
    public class NuGetPackage
    {
        private readonly string id;
        private readonly string version;

        public NuGetPackage(string id)
        {
            this.id = id;
        }

        public NuGetPackage(string id, string version)
        {
            this.id = id;
            this.version = version;
        }
        
        public string Id
        {
            get { return this.id; }
        }

        public string Version
        {
            get { return this.version; }
        }
    }
}

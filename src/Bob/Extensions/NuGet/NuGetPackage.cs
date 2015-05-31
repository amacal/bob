namespace Bob.Extensions.NuGet
{
    public class NuGetPackage
    {
        private readonly string name;

        public NuGetPackage(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}

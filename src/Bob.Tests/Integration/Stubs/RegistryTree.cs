namespace Bob.Tests.Integration.Stubs
{
    public class RegistryTree : RegistryContainer
    {
        private readonly string path;

        public RegistryTree(string path)
        {
            this.path = path;
        }

        public string Path
        {
            get { return this.path; }
        }

        public void Accept(RegistryVisitor vistor)
        {
            vistor.Visit(this);
        }
    }
}

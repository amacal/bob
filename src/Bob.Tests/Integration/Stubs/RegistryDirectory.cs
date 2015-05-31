namespace Bob.Tests.Integration.Stubs
{
    public class RegistryDirectory : RegistryContainer, RegistryNode
    {
        private readonly string name;

        public RegistryDirectory(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public void Accept(RegistryVisitor vistor)
        {
            vistor.Visit(this);
        }
    }
}

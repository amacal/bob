namespace Bob.Tests.Integration.Stubs
{
    public class RegistryText : RegistryNode
    {
        private readonly string key;
        private readonly string value;

        public RegistryText(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string Key
        {
            get { return this.key; }
        }

        public string Value
        {
            get { return this.value; }
        }

        public void Accept(RegistryVisitor vistor)
        {
            vistor.Visit(this);
        }
    }
}
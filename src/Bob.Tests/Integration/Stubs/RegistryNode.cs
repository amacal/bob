namespace Bob.Tests.Integration.Stubs
{
    public interface RegistryNode
    {
        void Accept(RegistryVisitor visitor);
    }
}
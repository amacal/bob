namespace Bob.Tests.Integration.Stubs
{
    public interface RegistryVisitor
    {
        void Visit(RegistryTree tree);

        void Visit(RegistryDirectory directory);

        void Visit(RegistryText text);
    }
}

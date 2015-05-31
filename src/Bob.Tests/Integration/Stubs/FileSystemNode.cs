namespace Bob.Tests.Integration.Stubs
{
    public interface FileSystemNode
    {
        void Accept(FileSystemVisitor visitor);
    }
}

namespace Bob.Tests.Integration.Stubs
{
    public interface FileSystemVisitor
    {
        void Visit(FileSystemTree tree);

        void Visit(FileSystemDirectory directory);

        void Visit(FileSystemFile file);
    }
}

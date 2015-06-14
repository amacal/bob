namespace Bob.Tests.Integration.Stubs
{
    public class FileSystemDirectory : FileSystemContainer, FileSystemNode
    {
        private readonly string name;

        public FileSystemDirectory(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public void Accept(FileSystemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
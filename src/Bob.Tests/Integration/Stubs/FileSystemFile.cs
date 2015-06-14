namespace Bob.Tests.Integration.Stubs
{
    public class FileSystemFile : FileSystemNode
    {
        private readonly string name;

        public FileSystemFile(string name)
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
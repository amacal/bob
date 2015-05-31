namespace Bob.Tests.Integration.Stubs
{
    public class FileSystemTree : FileSystemContainer, FileSystemNode
    {
        private readonly string path;

        public FileSystemTree(string path)
        {
            this.path = path;
        }

        public string Path
        {
            get { return this.path; }
        }

        public void Accept(FileSystemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

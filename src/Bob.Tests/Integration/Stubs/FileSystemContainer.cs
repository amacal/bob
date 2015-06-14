using System.Collections;
using System.Collections.Generic;

namespace Bob.Tests.Integration.Stubs
{
    public class FileSystemContainer : IEnumerable
    {
        private readonly List<FileSystemNode> nodes;

        protected FileSystemContainer()
        {
            this.nodes = new List<FileSystemNode>();
        }

        public void Add(FileSystemNode node)
        {
            this.nodes.Add(node);
        }

        public IEnumerator GetEnumerator()
        {
            return this.nodes.GetEnumerator();
        }
    }
}
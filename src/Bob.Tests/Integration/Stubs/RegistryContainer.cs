using System.Collections;
using System.Collections.Generic;

namespace Bob.Tests.Integration.Stubs
{
    public abstract class RegistryContainer : IEnumerable
    {
        private readonly List<RegistryNode> nodes;

        protected RegistryContainer()
        {
            this.nodes = new List<RegistryNode>();
        }

        public void Add(RegistryNode node)
        {
            this.nodes.Add(node);
        }

        public IEnumerator GetEnumerator()
        {
            return this.nodes.GetEnumerator();
        }
    }
}
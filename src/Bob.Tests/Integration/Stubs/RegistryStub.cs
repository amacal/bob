using Bob.Core;
using System.Collections.Generic;

namespace Bob.Tests.Integration.Stubs
{
    public class RegistryStub : IRegistry
    {
        private readonly List<RegistryTree> trees;

        public RegistryStub()
        {
            this.trees = new List<RegistryTree>();
        }

        public string[] Keys(string path)
        {
            var visitor = new RegistryKeyVisitor(path);

            foreach (RegistryTree tree in this.trees)
            {
                tree.Accept(visitor);
            }

            return visitor.GetKeys();
        }

        public string Value(string path)
        {
            var visitor = new RegistryValueVisitor(path);

            foreach (RegistryTree tree in this.trees)
            {
                tree.Accept(visitor);
            }

            return visitor.GetValue();
        }

        public void Register(RegistryTree tree)
        {
            this.trees.Add(tree);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Bob.Tests.Integration.Stubs
{
    public class RegistryValueVisitor : RegistryVisitor
    {
        private readonly string[] parts;
        private readonly List<string> values;
        private readonly List<string> current;

        public RegistryValueVisitor(string path)
        {
            this.parts = path.Split('\\');
            this.values = new List<string>();
            this.current = new List<string>();
        }

        public string GetValue()
        {
            return this.values.SingleOrDefault();
        }

        public void Visit(RegistryTree tree)
        {
            this.current.AddRange(tree.Path.Split('\\'));

            if (this.current.Count <= this.parts.Length)
            {
                if (this.StartsWith(this.parts, this.current) == true)
                {
                    foreach (RegistryNode node in tree)
                    {
                        node.Accept(this);
                    }
                }
            }

            this.current.Clear();
        }

        public void Visit(RegistryDirectory directory)
        {
            this.current.Add(directory.Name);

            if (this.current.Count <= this.parts.Length)
            {
                if (this.StartsWith(this.parts, this.current) == true)
                {
                    foreach (RegistryNode node in directory)
                    {
                        node.Accept(this);
                    }
                }
            }

            this.current.RemoveAt(this.current.Count - 1);
        }

        public void Visit(RegistryText text)
        {
            this.current.Add(text.Key);

            if (this.current.Count == this.parts.Length)
            {
                this.values.Add(text.Value);
            }

            this.current.RemoveAt(this.current.Count - 1);
        }

        private bool StartsWith(IList<string> total, IList<string> prefix)
        {
            for (int i = 0; i < prefix.Count; i++)
            {
                if (total[i] != prefix[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Bob.Tests.Integration.Stubs
{
    public class RegistryKeyVisitor : RegistryVisitor
    {
        private readonly string[] parts;
        private readonly HashSet<string> keys;
        private readonly List<string> current;

        public RegistryKeyVisitor(string path)
        {
            this.parts = path.Split('\\');
            this.keys = new HashSet<string>();
            this.current = new List<string>();
        }

        public string[] GetKeys()
        {
            return this.keys.ToArray();
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

            if (this.current.Count > this.parts.Length)
            {
                if (this.StartsWith(this.current, this.parts) == true)
                {
                    this.keys.Add(this.current[this.parts.Length]);
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

            if (this.current.Count == this.parts.Length + 1)
            {
                this.keys.Add(this.current[this.parts.Length]);
            }

            this.current.RemoveAt(this.current.Count - 1);
        }

        public void Visit(RegistryText text)
        {
            this.current.Add(text.Key);

            if (this.current.Count == this.parts.Length + 1)
            {
                this.keys.Add(this.current[this.parts.Length]);
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

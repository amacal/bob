using System;
using System.Collections.Generic;
using System.Linq;

using Bob.Core;

namespace Bob.Tests.Integration.Stubs
{
    public class FileSystemFilesVisitor : FileSystemVisitor
    {
        private readonly Glob pattern;
        private readonly string[] parts;
        private readonly HashSet<FileAtrifact> files;
        private readonly List<string> current;

        public FileSystemFilesVisitor(string directory, Glob pattern)
        {
            this.pattern = pattern;
            this.files = new HashSet<FileAtrifact>();
            this.current = new List<string>();

            this.parts = directory.Backslash().Split('\\');
        }

        public IEnumerable<string> GetFiles()
        {
            return this.files.Where(file => this.pattern.IsMatch(file.Match)).Select(file => file.FullName);
        }

        public void Visit(FileSystemTree tree)
        {
            this.current.AddRange(tree.Path.Backslash().Split('\\'));

            if (this.parts.Length <= this.current.Count)
            {
                if (this.StartsWith(this.current, this.parts) == true)
                {
                    foreach (FileSystemNode node in tree)
                    {
                        node.Accept(this);
                    }
                }
            }

            this.current.Clear();
        }

        public void Visit(FileSystemDirectory directory)
        {
            this.current.Add(directory.Name);

            if (this.parts.Length <= this.current.Count)
            {
                if (this.StartsWith(this.current, this.parts) == true)
                {
                    foreach (FileSystemNode node in directory)
                    {
                        node.Accept(this);
                    }
                }
            }

            this.current.RemoveAt(this.current.Count - 1);
        }

        public void Visit(FileSystemFile file)
        {
            if (this.current.Count >= this.parts.Length)
            {
                FileAtrifact artifact = new FileAtrifact
                {
                    FullName = String.Join("\\", this.current.Concat(Enumerable.Repeat(file.Name, 1))),
                    Match = String.Join("\\", this.current.Skip(this.parts.Length).Concat(Enumerable.Repeat(file.Name, 1)))
                };

                this.files.Add(artifact);
            }
        }

        private bool StartsWith(IList<string> total, IList<string> prefix)
        {
            for (int i = 0; i < prefix.Count; i++)
            {
                if (String.Equals(total[i], prefix[i], StringComparison.OrdinalIgnoreCase) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private struct FileAtrifact
        {
            public string FullName;
            public string Match;
        }
    }
}

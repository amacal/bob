using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bob.Core
{
    public class StorageServiceTemp : IStorageTemp
    {
        private readonly string path;

        public StorageServiceTemp(string directory)
        {
            this.path = directory.Backslash().TrimEnd('\\');
        }

        public string Path
        {
            get { return this.path; }
        }

        public string New(string extension)
        {
            string generated = System.IO.Path.GetTempFileName();
            string renamed = System.IO.Path.ChangeExtension(generated, extension);

            File.Move(generated, renamed);

            return renamed;
        }

        public IEnumerable<string> Files(Glob glob)
        {
            return Directory.EnumerateFiles(this.path, "*", SearchOption.AllDirectories).Select(this.Strip).Where(glob.IsMatch);
        }

        public IEnumerable<string> Directories(Glob glob)
        {
            return Directory.EnumerateDirectories(this.path, "*", SearchOption.AllDirectories).Select(this.Strip).Where(glob.IsMatch);
        }

        private string Strip(string name)
        {
            return name.Substring(this.path.Length + 1);
        }
    }
}

namespace Bob.Core
{
    public class StorageServiceData : IStorageData
    {
        private readonly string path;

        public StorageServiceData(string directory)
        {
            this.path = directory.Backslash().TrimEnd('\\');
        }

        public string Path
        {
            get { return this.path; }
        }
    }
}

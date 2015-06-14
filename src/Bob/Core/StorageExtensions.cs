namespace Bob.Core
{
    public static class StorageExtensions
    {
        public static string Backslash(this string path)
        {
            return path.Replace('/', '\\');
        }

        public static string Quote(this string path)
        {
            if (path.Contains(" ") == false)
            {
                return path;
            }

            return '"' + path + '"';
        }
    }
}
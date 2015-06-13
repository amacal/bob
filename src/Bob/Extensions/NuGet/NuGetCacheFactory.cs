namespace Bob.Extensions.NuGet
{
    public class NuGetCacheFactory
    {
        public NuGetCache Default()
        {
            return new NuGetDisableCache();
        }

        public NuGetCache Disable()
        {
            return new NuGetDisableCache();
        }

        public NuGetCache AppData()
        {
            return new NuGetAppDataCache();
        }
    }
}

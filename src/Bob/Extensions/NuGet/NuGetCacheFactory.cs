namespace Bob.Extensions.NuGet
{
    public class NuGetCacheFactory
    {
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

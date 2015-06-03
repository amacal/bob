namespace Bob.Extensions.NuGet
{
    public class NuGetDisableCache : NuGetCache
    {
        public string Resolve()
        {
            return null;
        }

        public void Apply(string path)
        {
        }
    }
}

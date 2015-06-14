namespace Bob.Extensions.NuGet
{
    public interface NuGetCache
    {
        string Resolve();

        void Apply(string path);
    }
}
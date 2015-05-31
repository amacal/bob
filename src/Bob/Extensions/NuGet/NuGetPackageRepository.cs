namespace Bob.Extensions.NuGet
{
    public class NuGetPackageRepository
    {
        public NuGetPackage Get(string name)
        {
            return new NuGetPackage(name);
        }
    }
}

namespace Bob.Extensions.MsBuild
{
    public class MsBuildPropertyRepository
    {
        public MsBuildPropertyRepositoryForConfiguration Configuration
        {
            get { return new MsBuildPropertyRepositoryForConfiguration(); }
        }
    }
}
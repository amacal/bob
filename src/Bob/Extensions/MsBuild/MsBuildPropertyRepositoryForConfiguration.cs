namespace Bob.Extensions.MsBuild
{
    public class MsBuildPropertyRepositoryForConfiguration
    {
        public MsBuildProperty Release()
        {
            return new MsBuildProperty("Configuration", "Release");
        }

        public MsBuildProperty Debug()
        {
            return new MsBuildProperty("Configuration", "Release");
        }

        public MsBuildProperty Value(string value)
        {
            return new MsBuildProperty("Configuration", value);
        }
    }
}

namespace Bob.Extensions.NUnit
{
    public class NUnitPathRepository
    {
        public NUnitPath Package()
        {
            return new NUnitPackagePath();
        }
    }
}

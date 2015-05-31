namespace Bob.Extensions.NUnit
{
    public class NUnitExecuteParameters
    {
        public NUnitPath Path { get; set; }

        public IFileSystemItem Assemblies { get; set; }

        public IFileSystemItem XmlResult { get; set; }
    }
}

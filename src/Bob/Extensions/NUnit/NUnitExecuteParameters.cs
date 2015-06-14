namespace Bob.Extensions.NUnit
{
    public class NUnitExecuteParameters
    {
        public NUnitPath Path { get; set; }

        public FileSystemItem Assemblies { get; set; }

        public FileSystemItem XmlResult { get; set; }
    }
}
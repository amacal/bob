namespace Bob.Extensions.ILRepack
{
    public class ILRepackMergeParameters
    {
        public ILRepackPath Path { get; set; }

        public FileSystemItem Output { get; set; }

        public FileSystemItem Primary { get; set; }

        public FileSystemItem Assemblies { get; set; }
    }
}
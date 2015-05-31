namespace Bob.Extensions.ILRepack
{
    public class ILRepackMergeParameters
    {
        public ILRepackPath Path { get; set; }

        public IFileSystemItem Output { get; set; }

        public IFileSystemItem Primary { get; set; }

        public IFileSystemItem Assemblies { get; set; }
    }
}

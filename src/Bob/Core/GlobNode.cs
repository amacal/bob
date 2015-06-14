namespace Bob.Core
{
    public interface GlobNode
    {
        void Accept(GlobVisitor visitor);
    }
}
namespace Bob.Core
{
    public class GlobSeparator : GlobNode
    {
        public void Accept(GlobVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
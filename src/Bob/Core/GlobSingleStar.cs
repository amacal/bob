namespace Bob.Core
{
    public class GlobSingleStar : GlobNode
    {
        public void Accept(GlobVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

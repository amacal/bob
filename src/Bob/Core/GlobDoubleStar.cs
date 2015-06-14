namespace Bob.Core
{
    public class GlobDoubleStar : GlobNode
    {
        public void Accept(GlobVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
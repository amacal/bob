namespace Bob.Core
{
    public class GlobQuestionMark : GlobNode
    {
        public void Accept(GlobVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

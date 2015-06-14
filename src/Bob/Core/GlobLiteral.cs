namespace Bob.Core
{
    public class GlobLiteral : GlobNode
    {
        private readonly char character;

        public GlobLiteral(char character)
        {
            this.character = character;
        }

        public char Character
        {
            get { return this.character; }
        }

        public void Accept(GlobVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
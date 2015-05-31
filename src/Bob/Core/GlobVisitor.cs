namespace Bob.Core
{
    public interface GlobVisitor
    {
        void Visit(GlobLiteral literal);

        void Visit(GlobQuestionMark questionMark);

        void Visit(GlobSingleStar singleStar);

        void Visit(GlobDoubleStar doubleStar);

        void Visit(GlobSeparator separator);

        void Visit(GlobDrive drive);

        void Visit(GlobNetwork network);
    }
}

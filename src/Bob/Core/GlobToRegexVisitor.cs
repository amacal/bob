using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bob.Core
{
    public class GlobToRegexVisitor : GlobVisitor
    {
        private readonly StringBuilder builder;

        public GlobToRegexVisitor()
        {
            this.builder = new StringBuilder();
        }

        public Regex GetRegex()
        {
            builder.Insert(0, "^");
            builder.Append("$");

            return new Regex(this.builder.ToString(), RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public void Visit(GlobLiteral literal)
        {
            this.builder.Append(Regex.Escape(literal.Character.ToString()));
        }

        public void Visit(GlobQuestionMark questionMark)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(GlobSingleStar singleStar)
        {
            this.builder.Append(@"[^/\\:]+");
        }

        public void Visit(GlobDoubleStar doubleStar)
        {
            this.builder.Append(@"[^\?]+");
        }

        public void Visit(GlobSeparator separator)
        {
            this.builder.Append(@"\\");
        }

        public void Visit(GlobDrive drive)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(GlobNetwork network)
        {
            throw new System.NotImplementedException();
        }
    }
}

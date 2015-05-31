using System.Text.RegularExpressions;

namespace Bob.Core
{
    public class Glob
    {
        private readonly string pattern;
        private readonly Regex regex;

        public Glob(string pattern, Regex regex)
        {
            this.pattern = pattern;
            this.regex = regex;
        }

        public string Pattern
        {
            get { return this.pattern; }
        }

        public bool IsMatch(string path)
        {
            return this.regex.IsMatch(path);
        }

        public static Glob Parse(string pattern)
        {
            GlobParser parser = new GlobParser(pattern);
            GlobToRegexVisitor visitor = new GlobToRegexVisitor();

            foreach (GlobNode node in parser.Parse())
            {
                node.Accept(visitor);
            }

            return new Glob(pattern, visitor.GetRegex());
        }
    }
}

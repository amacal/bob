namespace Bob.Tests.Integration.Stubs
{
    public class ShellMatch
    {
        public static readonly ShellMatch OK = new ShellMatch();

        private readonly string reason;

        private ShellMatch()
        {
        }

        public ShellMatch(string reason)
        {
            this.reason = reason;
        }

        public override string ToString()
        {
            return this.reason;
        }
    }
}

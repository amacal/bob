namespace Bob.Core
{
    public class GlobDrive
    {
        private readonly char letter;

        public GlobDrive(char letter)
        {
            this.letter = letter;
        }

        public char Letter
        {
            get { return this.letter; }
        }
    }
}

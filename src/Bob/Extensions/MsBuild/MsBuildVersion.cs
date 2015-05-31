using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Bob.Extensions.MsBuild
{
    public class MsBuildVersion
    {
        private static readonly Regex Regex;

        static MsBuildVersion()
        {
            MsBuildVersion.Regex = new Regex(@"^(?<major>[0-9]+)\.(?<minor>[0-9]+)$", RegexOptions.Compiled);
        }

        private readonly int major;
        private readonly int minor;

        public MsBuildVersion(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        public int Major
        {
            get { return this.major; }
        }

        public int Minor
        {
            get { return this.minor; }
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}", this.Major, this.Minor);
        }

        public static MsBuildVersion Parse(string text)
        {
            Match match = MsBuildVersion.Regex.Match(text);

            if (match.Success == false)
            {
                return null;
            }

            int major = Int32.Parse(match.Groups["major"].Value, CultureInfo.InvariantCulture);
            int minor = Int32.Parse(match.Groups["minor"].Value, CultureInfo.InvariantCulture);

            return new MsBuildVersion(major, minor);
        }
    }
}

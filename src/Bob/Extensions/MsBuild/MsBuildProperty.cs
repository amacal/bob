namespace Bob.Extensions.MsBuild
{
    public class MsBuildProperty
    {
        private readonly string name;
        private readonly string value;

        public MsBuildProperty(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Value
        {
            get { return this.value; }
        }
    }
}
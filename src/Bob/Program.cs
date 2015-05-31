using System.IO;

using Bob.Core;

namespace Bob
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string script = File.ReadAllText(args[0]);

            Pipeline pipeline = new Pipeline();
            IBob bob = Runner.Compile(script);

            bob.Execute(pipeline);
            pipeline.Execute("Default");
        }
    }
}

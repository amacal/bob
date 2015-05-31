using System.IO;

using Bob.Core;

namespace Bob
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            string script = File.ReadAllText(args[0]);

            Pipeline pipeline = new Pipeline();
            IBob bob = Runner.Compile(script);

            bob.Execute(pipeline);
            TaskResult result = pipeline.Execute("Default");

            return result == TaskResult.Successful ? 0 : -1;
        }
    }
}

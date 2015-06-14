using Bob.Core;
using System.IO;

namespace Bob
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            string script = args.Length > 0 ? File.ReadAllText(args[0]) : null;
            string target = args.Length > 1 ? args[1] : null;

            if (script != null)
            {
                TaskResult result;
                Pipeline pipeline = new Pipeline();
                IBob bob = Runner.Compile(script);

                bob.Execute(pipeline);
                result = target == null ? pipeline.Execute() : pipeline.Execute(target);

                return result == TaskResult.Successful ? 0 : -1;
            }

            return -1;
        }
    }
}
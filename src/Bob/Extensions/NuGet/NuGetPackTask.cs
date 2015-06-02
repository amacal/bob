using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Bob.Core;

namespace Bob.Extensions.NuGet
{
    public class NuGetPackTask : ITask
    {
        private readonly Func<NuGetPackParameters> parameters;

        public NuGetPackTask(Func<NuGetPackParameters> parameters)
        {
            this.parameters = parameters;
        }

        public TaskResult Execute()
        {
            return this.Execute(this.parameters());
        }

        private TaskResult Execute(NuGetPackParameters data)
        {
            StringBuilder arguments = new StringBuilder("pack ");
            string tool = data.Path.Resolve();

            if (data.Specification != null)
            {
                arguments.Append(data.Specification.Resolve().Quote());
                arguments.Append(" ");
            }

            if (data.Output != null)
            {
                arguments.Append("-o ");
                arguments.Append(data.Output.Execute().Single().Quote());
                arguments.Append(" ");
            }

            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = tool,
                WorkingDirectory = Container.Storage.Local.Path,
                Arguments = arguments.ToString().TrimEnd()
            };

            if (Container.Shell.Start(info) != 0)
            {
                return TaskResult.Unsuccessful;
            }

            return TaskResult.Successful;
        }
    }
}

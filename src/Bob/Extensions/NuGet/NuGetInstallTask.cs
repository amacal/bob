using Bob.Core;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Bob.Extensions.NuGet
{
    public class NuGetInstallTask : ITask
    {
        private readonly Func<NuGetInstallParameters> parameters;

        public NuGetInstallTask(Func<NuGetInstallParameters> parameters)
        {
            this.parameters = parameters;
        }

        public TaskResult Execute()
        {
            return this.Execute(this.parameters());
        }

        private TaskResult Execute(NuGetInstallParameters data)
        {
            StringBuilder arguments = new StringBuilder("install ");
            string tool = data.Path.Resolve();

            if (data.Package != null)
            {
                arguments.Append(data.Package.Id);
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
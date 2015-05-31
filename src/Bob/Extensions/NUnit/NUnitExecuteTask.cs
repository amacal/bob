using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Bob.Core;

namespace Bob.Extensions.NUnit
{
    public class NUnitExecuteTask : ITask
    {
        private readonly Func<NUnitExecuteParameters> parameters;

        public NUnitExecuteTask(Func<NUnitExecuteParameters> parameters)
        {
            this.parameters = parameters;
        }

        public TaskResult Execute()
        {
            return this.Execute(this.parameters());
        }

        private TaskResult Execute(NUnitExecuteParameters data)
        {
            StringBuilder arguments = new StringBuilder();
            string tool = data.Path.Resolve();

            if (data.XmlResult != null)
            {
                arguments.Append("/xml:");
                arguments.Append(data.XmlResult.Execute().Single().Quote());
                arguments.Append(" ");
            }

            foreach (string assembly in data.Assemblies.Execute())
            {
                arguments.Append(assembly.Quote());
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

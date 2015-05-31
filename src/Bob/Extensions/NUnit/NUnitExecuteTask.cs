using System;
using System.Diagnostics;
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

        public void Execute()
        {
            this.Execute(this.parameters());
        }

        private void Execute(NUnitExecuteParameters data)
        {
            StringBuilder arguments = new StringBuilder();
            string tool = data.Path.Resolve();

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

            Container.Shell.Start(info);
        }
    }
}

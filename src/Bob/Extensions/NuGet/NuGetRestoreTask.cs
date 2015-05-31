using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Bob.Core;

namespace Bob.Extensions.NuGet
{
    public class NuGetRestoreTask : ITask
    {
        private readonly Func<NuGetRestoreParameters> parameters;

        public NuGetRestoreTask(Func<NuGetRestoreParameters> parameters)
        {
            this.parameters = parameters;
        }

        public void Execute()
        {
            this.Execute(this.parameters());
        }

        private void Execute(NuGetRestoreParameters data)
        {
            StringBuilder arguments = new StringBuilder("restore ");
            string tool = data.Path.Resolve();

            if (data.Solution != null)
            {
                arguments.Append(data.Solution.Execute().Single());
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

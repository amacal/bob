﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Bob.Core;

namespace Bob.Extensions.ILRepack
{
    public class ILRepackMergeTask : ITask
    {
        private readonly Func<ILRepackMergeParameters> parameters;

        public ILRepackMergeTask(Func<ILRepackMergeParameters> parameters)
        {
            this.parameters = parameters;
        }

        public void Execute()
        {
            this.Execute(this.parameters());
        }

        private void Execute(ILRepackMergeParameters data)
        {
            StringBuilder arguments = new StringBuilder();
            string tool = data.Path.Resolve();

            if (data.Output != null)
            {
                arguments.Append("/out:");
                arguments.Append(data.Output.Execute().Single().Quote());
                arguments.Append(" ");
            }

            if (data.Primary != null)
            {
                arguments.Append(data.Primary.Execute().Single().Quote());
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

            Container.Shell.Start(info);
        }
    }
}

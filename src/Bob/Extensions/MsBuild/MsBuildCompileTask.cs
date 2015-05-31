using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using Bob.Core;

namespace Bob.Extensions.MsBuild
{
    public class MsBuildCompileTask : ITask
    {
        private readonly Func<MsBuildCompileParameters> parameters;

        public MsBuildCompileTask(Func<MsBuildCompileParameters> parameters)
        {
            this.parameters = parameters;
        }

        public void Execute()
        {
            this.Execute(this.parameters());
        }

        private void Execute(MsBuildCompileParameters data)
        {
            string path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions";
            ICollection<MsBuildVersion> versions = this.GetMsBuildVersions(path);
            
            MsBuildVersion version = versions.OrderByDescending(x => x.Major).ThenByDescending(x => x.Minor).First();
            path = path + "\\" + version.ToString() + "\\MSBuildToolsPath";

            string tool = Path.Combine(Container.Registry.Value(path), "msbuild.exe");
            StringBuilder arguments = new StringBuilder();

            if (data.Solution != null)
            {
                arguments.Append(data.Solution.Execute().Single());
                arguments.Append(" ");
            }

            if (data.Output != null)
            {
                arguments.AppendFormat("/p:OutDir={0}", data.Output.Execute().Single());
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

        private ICollection<MsBuildVersion> GetMsBuildVersions(string path)
        {
            ICollection<MsBuildVersion> versions = new List<MsBuildVersion>();
            string[] keys = Container.Registry.Keys(path);           

            foreach (string key in keys)
            {
                MsBuildVersion version = MsBuildVersion.Parse(key);
                if (version != null)
                {
                    versions.Add(version);
                }
            }

            return versions;
        }
    }
}

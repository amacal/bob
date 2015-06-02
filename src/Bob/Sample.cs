using System;
using System.Collections.Generic;

namespace Bob
{
    public class Sample : IBob
    {
        private ITask Restore()
        {
            return NuGet.Restore(parameters => {});
        }

        private IEnumerable<ITask> Compile()
        {
            yield return FileSystem.NewDirectory(parameters =>
            {
                parameters.Path = FileSystem.Directories.Relative("build\\output");
            });

            yield return MsBuild.Compile(parameters =>
            {
                parameters.Solution = FileSystem.Files.Match("*.sln");
                parameters.Output = FileSystem.Directories.Relative("build\\output");
            });
        }

        private ITask Test()
        {
            return NUnit.Execute(parameters =>
            {
                parameters.Assemblies = FileSystem.Files.Match("*.dll");
            });
        }

        private ITask Pack()
        {
            return NuGet.Pack(parameters =>
            {
                parameters.Specification = NuGet.Specification.Inline(package =>
                {
                });
            });
        }

        private ITask Deploy()
        {
            return PowerShell.Execute(parameters =>
            {
                parameters.Script = @"deploy.ps1";
            });
        }

        public void Execute(IPipeline pipeline)
        {
            pipeline.Define(Restore, Compile, Test, Deploy);
        }
    }
}

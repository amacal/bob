using System.Collections.Generic;

namespace Bob
{
    public class Sample : IBob
    {
        private ITask Configure()
        {
            return NuGet.Configure(parameters =>
            {
                parameters.Path = NuGet.Path.Online(settings =>
                {
                    settings.Cache = NuGet.Cache.AppData();
                });
            });
        }

        private ITask Restore()
        {
            return NuGet.Restore();
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

                parameters.Properties.Add(MsBuild.Properties.Configuration.Release());
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
                    package.Dependencies.Add("NUnit", "2.6.4");
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
            pipeline.Define(Configure, Restore, Compile, Test, Deploy);
        }
    }
}
using Bob.Tests.Integration.Stubs;
using TechTalk.SpecFlow;

namespace Bob.Tests.Integration.Steps
{
    [Binding]
    public class OpenSourceSteps
    {
        private readonly Core core;

        public OpenSourceSteps(Core core)
        {
            this.core = core;
        }

        [Given(@"there is NetJSON repository cloned into ""(.*)"" directory")]
        public void GivenThereIsNetJsonRepositoryClonedIntoDirectory(string directory)
        {
            FileSystemTree tree = new FileSystemTree(directory)
            {
                new FileSystemFile("NetJSON.sln"),
                new FileSystemDirectory("NetJSON"),
                new FileSystemDirectory("NetJSON.V3_5"),
                new FileSystemDirectory("NetJSON.Tests")
            };

            this.core.Storage.Register(tree);
        }

        [Given(@"there is npgsql repository cloned into ""(.*)"" directory")]
        public void GivenThereIsNpgsqlRepositoryClonedIntoDirectory(string directory)
        {
            FileSystemTree tree = new FileSystemTree(directory)
            {
                new FileSystemFile("Npgsql2010.sln"),
                new FileSystemFile("Npgsql2012.sln"),
                new FileSystemFile("Npgsql2013.sln"),
                new FileSystemDirectory(".nuget")
                {
                    new FileSystemFile("NuGet.exe")
                },
                new FileSystemDirectory("Npgsql.EntityFramework"),
                new FileSystemDirectory("Npgsql"),
                new FileSystemDirectory("NpgsqlDdexProvider"),
                new FileSystemDirectory("Tools"),
                new FileSystemDirectory("packages"),
                new FileSystemFile("template.nuspec")
            };

            this.core.Storage.Register(tree);
        }

        [Given(@"there is npgsql repository already restored in ""(.*)"" directory")]
        public void GivenThereIsNpgsqlRepositoryAlreadyRestoredInDirectory(string directory)
        {
            FileSystemTree tree = new FileSystemTree(directory)
            {
                new FileSystemDirectory("NUnit.2.6.4")
                {
                    new FileSystemDirectory("lib")
                    {
                        new FileSystemFile("nunit.framework.dll")
                    }
                },
                new FileSystemDirectory("NUnit.Runners.2.6.4")
                {
                    new FileSystemDirectory("tools")
                    {
                        new FileSystemFile("nunit-console.exe")
                    }
                }
            };

            this.core.Storage.Register(tree);
        }

        [Given(@"there is npgsql repository already compiled in ""(.*)"" directory")]
        public void GivenThereIsNpgsqlRepositoryAlreadyCompiledInDirectory(string directory)
        {
            FileSystemTree tree = new FileSystemTree(directory)
            {
                new FileSystemFile("Npgsql.dll"),
                new FileSystemFile("Npgsql.pdb"),
                new FileSystemFile("Npgsql.xml"),
                new FileSystemFile("Npgsql.Tests.dll"),
                new FileSystemFile("Npgsql.Tests.pdb")
            };

            this.core.Storage.Register(tree);
        }

        [Given(@"there is bob repository cloned into ""(.*)"" directory")]
        public void GivenThereIsBobRepositoryClonedIntoDirectory(string directory)
        {
            FileSystemTree tree = new FileSystemTree(directory)
            {
                new FileSystemFile("Bob.2013.Community.sln")
            };

            this.core.Storage.Register(tree);
        }

        [Given(@"there is bob repository already restored in ""(.*)"" directory")]
        public void GivenThereIsBobRepositoryAlreadyRestoredInDirectory(string directory)
        {
            FileSystemTree tree = new FileSystemTree(directory)
            {
                new FileSystemDirectory("NUnit.2.6.4"),
                new FileSystemDirectory("SpecFlow.1.9.0"),
                new FileSystemDirectory("ilrepack.1.26.0")
                {
                    new FileSystemDirectory("tools")
                    {
                        new FileSystemFile("ILRepack.exe")
                    }
                }
            };

            this.core.Storage.Register(tree);
        }

        [Given(@"there is bob repository already compiled in ""(.*)"" directory")]
        public void GivenThereIsBobRepositoryAlreadyCompiledInDirectory(string directory)
        {
            FileSystemTree tree = new FileSystemTree(directory)
            {
                new FileSystemFile("Bob.exe"),
                new FileSystemFile("Bob.pdb"),
                new FileSystemFile("Microsoft.CodeAnalysis.dll"),
                new FileSystemFile("Microsoft.CodeAnalysis.xml"),
                new FileSystemFile("Microsoft.CodeAnalysis.CSharp.dll"),
                new FileSystemFile("Microsoft.CodeAnalysis.CSharp.xml")
            };

            this.core.Storage.Register(tree);
        }
    }
}
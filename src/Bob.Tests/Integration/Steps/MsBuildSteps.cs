using Bob.Tests.Integration.Stubs;
using TechTalk.SpecFlow;

namespace Bob.Tests.Integration.Steps
{
    [Binding]
    public class MsBuildSteps
    {
        private readonly Core core;

        public MsBuildSteps(Core core)
        {
            this.core = core;
        }

        [Given(@"a MsBuild version 12.0 is available")]
        public void GivenMsBuildVersionTwelveIsAvailable()
        {
            RegistryTree tree = new RegistryTree(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild")
            {
                new RegistryDirectory("12.0"),
                new RegistryDirectory("ToolsVersions")
                {
                    new RegistryDirectory("12.0")
                    {
                        new RegistryText("MSBuildToolsPath", @"C:\Program Files (x86)\MSBuild\12.0\bin\amd64\")
                    }
                }
            };

            this.core.Registry.Register(tree);
        }
    }
}

using System;
using System.IO;

using TechTalk.SpecFlow;

namespace Bob.Tests.Integration.Steps
{
    [Binding]
    public class StorageSteps
    {
        private readonly Core core;

        public StorageSteps(Core core)
        {
            this.core = core;
        }

        [Given(@"""(.*)"" is the working directory")]
        public void GivenTheWorkingDirectory(string directory)
        {
            this.core.Storage.SetWorkingDirectory(directory);
        }

        [Given(@"""(.*)"" is the temp directory")]
        public void GivenTheTempDirectory(string directory)
        {
            this.core.Storage.SetTempDirectory(directory);
        }
    }
}

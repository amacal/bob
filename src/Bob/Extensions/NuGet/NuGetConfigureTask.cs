using System;

using Bob.Core;

namespace Bob.Extensions.NuGet
{
    public class NuGetConfigureTask : ITask
    {
        private readonly Func<NuGetConfigureParameters> parameters;

        public NuGetConfigureTask(Func<NuGetConfigureParameters> parameters)
        {
            this.parameters = parameters;
        }

        public TaskResult Execute()
        {
            return this.Execute(this.parameters());
        }

        private TaskResult Execute(NuGetConfigureParameters data)
        {
            if (data.Path != null)
            {
                NuGetConfiguration.Instance.Path = data.Path;
            }

            return TaskResult.Successful;
        }
    }
}

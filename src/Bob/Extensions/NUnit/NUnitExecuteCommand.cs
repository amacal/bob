using System;

namespace Bob.Extensions.NUnit
{
    public class NUnitExecuteCommand
    {
        public ITask Execute(Action<NUnitExecuteParameters> parameters)
        {
            return new NUnitExecuteTask(() =>
            {
                NUnitExecuteParameters instance = new NUnitExecuteParameters
                {
                    Path = Bob.NUnit.Path.Package()
                };

                parameters(instance);
                return instance;
            });
        }
    }
}

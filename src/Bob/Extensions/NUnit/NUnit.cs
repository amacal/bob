using Bob.Extensions.NUnit;
using System;

namespace Bob
{
    public static class NUnit
    {
        public static NUnitPathRepository Path
        {
            get { return new NUnitPathRepository(); }
        }

        public static ITask Execute(Action<NUnitExecuteParameters> parameters)
        {
            return NUnitCommands.Execute().Execute(parameters);
        }
    }
}
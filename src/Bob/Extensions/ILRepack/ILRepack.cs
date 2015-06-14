using Bob.Extensions.ILRepack;
using System;

namespace Bob
{
    public class ILRepack
    {
        public static ILRepackPathRepository Path
        {
            get { return new ILRepackPathRepository(); }
        }

        public static ITask Merge(Action<ILRepackMergeParameters> parameters)
        {
            return ILRepackCommands.Merge().Execute(parameters);
        }
    }
}
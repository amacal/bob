using System;

namespace Bob.Extensions.ILRepack
{
    public class ILRepackMergeCommand
    {
        public ITask Execute(Action<ILRepackMergeParameters> parameters)
        {
            return new ILRepackMergeTask(() =>
            {
                ILRepackMergeParameters instance = new ILRepackMergeParameters
                {
                    Path = Bob.ILRepack.Path.Package()
                };

                parameters(instance);
                return instance;
            });
        }
    }
}

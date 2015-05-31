using System;

namespace Bob
{
    public interface IPipeline
    {
        void Define(params Func<object>[] tasks);
    }
}

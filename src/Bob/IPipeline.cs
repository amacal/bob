using System;

namespace Bob
{
    public interface IPipeline
    {
        void Default(Func<object> task);

        void Define(params Func<object>[] tasks);
    }
}

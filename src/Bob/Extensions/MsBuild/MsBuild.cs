using Bob.Extensions.MsBuild;
using System;

namespace Bob
{
    public static class MsBuild
    {
        public static MsBuildPropertyRepository Properties
        {
            get { return new MsBuildPropertyRepository(); }
        }

        public static ITask Compile(Action<MsBuildCompileParameters> parameters)
        {
            return MsBuildCommands.Compile().Execute(parameters);
        }
    }
}
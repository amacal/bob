using System;

using Bob.Extensions.MsBuild;

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

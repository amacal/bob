namespace Bob.Extensions.MsBuild
{
    public static class MsBuildCommands
    {
        public static MsBuildCompileCommand Compile()
        {
            return new MsBuildCompileCommand();
        }
    }
}
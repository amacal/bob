namespace Bob.Extensions.NUnit
{
    public static class NUnitCommands
    {
        public static NUnitExecuteCommand Execute()
        {
            return new NUnitExecuteCommand();
        }
    }
}
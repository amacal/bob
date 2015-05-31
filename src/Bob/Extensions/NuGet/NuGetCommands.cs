namespace Bob.Extensions.NuGet
{
    public static class NuGetCommands
    {
        public static NuGetRestoreCommand Restore()
        {
            return new NuGetRestoreCommand();
        }
    }
}

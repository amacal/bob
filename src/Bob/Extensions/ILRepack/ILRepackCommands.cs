namespace Bob.Extensions.ILRepack
{
    public static class ILRepackCommands
    {
        public static ILRepackMergeCommand Merge()
        {
            return new ILRepackMergeCommand();
        }
    }
}

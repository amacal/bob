namespace Bob.Core
{
    public interface Task
    {
        string Name { get; }

        void Execute();
    }
}

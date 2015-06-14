namespace Bob.Core
{
    public interface IRegistry
    {
        string[] Keys(string path);

        string Value(string path);
    }
}
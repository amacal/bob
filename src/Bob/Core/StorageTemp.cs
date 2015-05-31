using System.Collections.Generic;

namespace Bob.Core
{
    public interface IStorageTemp
    {
        string Path { get; }

        IEnumerable<string> Files(Glob pattern);

        IEnumerable<string> Directories(Glob pattern);
    }
}

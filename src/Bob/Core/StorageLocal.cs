using System.Collections.Generic;

namespace Bob.Core
{
    public interface IStorageLocal
    {
        string Path { get; }

        IEnumerable<string> Files(Glob pattern);

        IEnumerable<string> Directories(Glob pattern);
    }
}

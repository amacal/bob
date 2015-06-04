using System.Collections.Generic;

namespace Bob.Core
{
    public interface IStorageData
    {
        string Path { get; }

        IEnumerable<string> Files(Glob pattern);
    }
}

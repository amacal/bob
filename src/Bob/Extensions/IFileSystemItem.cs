using System.Collections.Generic;

namespace Bob.Extensions
{
    public interface IFileSystemItem
    {
        IEnumerable<string> Execute();
    }
}

using System.Collections.Generic;

namespace Bob.Extensions
{
    public interface FileSystemItem
    {
        IEnumerable<string> Execute();
    }
}
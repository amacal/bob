using System.Diagnostics;

namespace Bob.Core
{
    public interface IShell
    {
        int Start(ProcessStartInfo info);
    }
}
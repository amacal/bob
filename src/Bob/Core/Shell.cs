using System.Diagnostics;

namespace Bob.Core
{
    public interface IShell
    {
        void Start(ProcessStartInfo info);
    }
}

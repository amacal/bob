using System;
using System.Diagnostics;

namespace Bob.Core
{
    public class ShellService : IShell
    {
        public int Start(ProcessStartInfo info)
        {
            info.UseShellExecute = false;

            Process process = Process.Start(info);

            process.WaitForExit();

            return process.ExitCode;
        }
    }
}

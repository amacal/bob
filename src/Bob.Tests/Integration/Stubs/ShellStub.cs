using Bob.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bob.Tests.Integration.Stubs
{
    public class ShellStub : IShell
    {
        private readonly List<ProcessStartInfo> executed;

        public ShellStub()
        {
            this.executed = new List<ProcessStartInfo>();
        }

        public int Start(ProcessStartInfo info)
        {
            this.executed.Add(info);
            return 0;
        }

        public ShellMatch Match(Func<ProcessStartInfo, ShellMatch> predicate)
        {
            return this.executed.Select(predicate).FirstOrDefault(x => x != ShellMatch.OK) ?? ShellMatch.OK;
        }
    }
}
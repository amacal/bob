using System;
using System.Diagnostics;
using System.IO;

using NUnit.Framework;
using TechTalk.SpecFlow;

using Bob.Tests.Integration.Stubs;

namespace Bob.Tests.Integration.Steps
{
    [Binding]
    public class ShellSteps
    {
        private readonly Core core;

        public ShellSteps(Core core)
        {
            this.core = core;
        }

        [Then(@"the following process is being executed")]
        public void ThenTheFollowingProcessIsBeingExecuted(Table table)
        {
            Func<ProcessStartInfo, bool> predicate = info =>
            {
                foreach (TableRow row in table.Rows)
                {
                    switch (row["Parameter"])
                    {
                        case "Process":

                            if (String.Equals(info.FileName, row["Value"].Escape(), StringComparison.OrdinalIgnoreCase) == false)
                            {
                                return false;
                            }

                            break;

                        case "WorkingDirectory":

                            if (String.Equals(info.WorkingDirectory, row["Value"].Escape(), StringComparison.OrdinalIgnoreCase) == false)
                            {
                                return false;
                            }

                            break;

                        case "Arguments":

                            if (info.Arguments != row["Value"].Escape())
                            {
                                return false;
                            }

                            break;
                    }
                }

                return true;
            };

            Assert.That(this.core.Shell.Any(predicate), Is.True);
        }
    }

    internal static class Extensions
    {
        public static string Escape(this string text)
        {
            return text.Replace("\n", "\\n");
        }
    }
}

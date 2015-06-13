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
            Func<ProcessStartInfo, ShellMatch> predicate = info =>
            {
                foreach (TableRow row in table.Rows)
                {
                    switch (row["Parameter"])
                    {
                        case "Process":

                            if (String.Equals(info.FileName, row["Value"].Escape(), StringComparison.OrdinalIgnoreCase) == false)
                            {
                                return new ShellMatch(String.Format("filename: '{0}' <> '{1}'", info.FileName, row["Value"].Escape()));
                            }

                            break;

                        case "WorkingDirectory":

                            if (String.Equals(info.WorkingDirectory, row["Value"].Escape(), StringComparison.OrdinalIgnoreCase) == false)
                            {
                                return new ShellMatch(String.Format("working-directory: '{0}' <> '{1}'", info.WorkingDirectory, row["Value"].Escape()));
                            }

                            break;

                        case "Arguments":

                            if (info.Arguments != row["Value"].Escape())
                            {
                                return new ShellMatch(String.Format("arguments: '{0}' <> '{1}'", info.Arguments, row["Value"].Escape()));
                            }

                            break;
                    }
                }

                return ShellMatch.OK;
            };

            Assert.That(this.core.Shell.Match(predicate), Is.EqualTo(ShellMatch.OK));
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

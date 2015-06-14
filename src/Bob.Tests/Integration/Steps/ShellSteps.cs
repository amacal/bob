using Bob.Tests.Integration.Stubs;
using NUnit.Framework;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

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

                            if (Equals(info.FileName, row["Value"].Escape()) == false)
                            {
                                return new ShellMatch(String.Format("filename: '{0}' <> '{1}'", info.FileName, row["Value"].Escape()));
                            }

                            break;

                        case "WorkingDirectory":

                            if (Equals(info.WorkingDirectory, row["Value"].Escape()) == false)
                            {
                                return new ShellMatch(String.Format("working-directory: '{0}' <> '{1}'", info.WorkingDirectory, row["Value"].Escape()));
                            }

                            break;

                        case "Arguments":

                            if (Equals(info.Arguments, row["Value"].Escape()) == false)
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

        private static bool Equals(string left, string right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (Char.ToLower(left[i]) == Char.ToLower(right[i]))
                {
                    continue;
                }

                if ((left[i] == '\\' || left[i] == '/') && (right[i] == '\\' || right[i] == '/'))
                {
                    continue;
                }

                return false;
            }

            return true;
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
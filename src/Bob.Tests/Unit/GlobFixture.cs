using System.Collections.Generic;
using System.Linq;

using Bob.Core;
using NUnit.Framework;

namespace Bob.Tests.Unit
{
    [TestFixture]
    public class GlobFixture
    {
        [Test]
        [TestCaseSource(typeof(ScenarioFactory), "Default")]
        public void GlobShouldConstraintPaths(ScenarioItem scenario)
        {
            Assert.That(scenario.Input.Where(scenario.Glob.IsMatch), Is.EquivalentTo(scenario.Output));
        }

        public class ScenarioItem
        {
            public Glob Glob;

            public ICollection<string> Input;

            public ICollection<string> Output;
        }

        public class ScenarioFactory
        {
            public static IEnumerable<ScenarioItem> Default()
            {
                yield return new ScenarioItem
                {
                    Glob = Glob.Parse("*.cs"),
                    Input = new[]
                    {
                        @"program.cs",
                        @"program.txt"
                    },
                    Output = new[]
                    {
                        @"program.cs"
                    }
                };

                yield return new ScenarioItem
                {
                    Glob = Glob.Parse("**.cs"),
                    Input = new[]
                    {
                        @"program.cs",
                        @"program.txt",
                        @"properties\assembly.cs",
                        @"properties\assembly.info"
                    },
                    Output = new[]
                    {
                        @"program.cs",
                        @"properties\assembly.cs"
                    }
                };

                yield return new ScenarioItem
                {
                    Glob = Glob.Parse("program.*"),
                    Input = new[]
                    {
                        @"program.cs",
                        @"program.txt",
                        @"properties\assembly.cs",
                        @"properties\assembly.info"
                    },
                    Output = new[]
                    {
                        @"program.cs",
                        @"program.txt"
                    }
                };
            }
        }
    }
}

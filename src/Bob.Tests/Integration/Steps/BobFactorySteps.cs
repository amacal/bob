using Bob.Core;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Bob.Tests.Integration.Steps
{
    [Binding]
    public class BobFactorySteps
    {
        [When(@"I execute the following task")]
        public void WhenIExecuteTheFollowingTask(Table table)
        {
            string code = String.Join(Environment.NewLine, table.Rows.Select(x => x["Code"]));
            string script = @"

                using Bob;

                public class Sample : IBob
                {
                    private ITask Default()
                    {
                        return " + code + @";
                    }

                    public void Execute(IPipeline pipeline)
                    {
                        pipeline.Define(Default);
                    }
                }

                            ";

            Pipeline pipeline = new Pipeline();
            IBob bob = Runner.Compile(script);

            bob.Execute(pipeline);
            pipeline.Execute("Default");
        }
    }
}
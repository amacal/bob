using System;
using System.Collections.Generic;

namespace Bob.Core
{
    public class Pipeline : IPipeline
    {
        private static readonly List<Func<object, Task>> handlers;

        static Pipeline()
        {
            Pipeline.handlers = new List<Func<object,Task>>
            {
                TaskFunction.Create,
                TaskFunctionEnumerator.Create
            };
        }

        private readonly List<Task[]> definition;

        public Pipeline()
        {
            this.definition = new List<Task[]>();
        }

        public void Define(params Func<object>[] tasks)
        {
            List<Task> instances = new List<Task>();

            foreach (object task in tasks)
            {
                foreach (Func<object, Task> handler in Pipeline.handlers)
                {
                    Task instance = handler.Invoke(task);

                    if (instance != null)
                    {
                        instances.Add(instance);
                    }
                }
            }

            this.definition.Add(instances.ToArray());
        }

        public void Execute(string task)
        {
            foreach (Task item in this.definition[0])
            {
                item.Execute();
            }
        }
    }
}

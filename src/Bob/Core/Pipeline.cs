using System;
using System.Collections.Generic;
using System.Linq;

namespace Bob.Core
{
    public class Pipeline : IPipeline
    {
        private static readonly List<Func<object, Task>> handlers;

        static Pipeline()
        {
            Pipeline.handlers = new List<Func<object, Task>>
            {
                TaskFunction.Create,
                TaskFunctionEnumerator.Create
            };
        }

        private Task defaultTarget;
        private readonly List<TaskChain> chains;

        public Pipeline()
        {
            this.chains = new List<TaskChain>();
        }

        public void Default(Func<object> task)
        {
            this.defaultTarget = this.GetTaskByHandler(task);
        }

        public void Define(params Func<object>[] tasks)
        {
            TaskChain chain = new TaskChain();

            foreach (Func<object> task in tasks)
            {
                Task instance = this.GetTaskByHandler(task);

                if (instance != null)
                {
                    chain.Add(instance);
                }
            }

            this.chains.Add(chain);
        }

        private Task GetTaskByHandler(Func<object> task)
        {
            foreach (Func<object, Task> handler in Pipeline.handlers)
            {
                Task instance = handler.Invoke(task);

                if (instance != null)
                {
                    return instance;
                }
            }

            return null;
        }

        public TaskResult Execute()
        {
            if (this.defaultTarget != null)
            {
                return this.Execute(this.defaultTarget.Name);
            }
            else
            {
                return this.chains.Single().Execute();
            }
        }

        public TaskResult Execute(string target)
        {
            TaskChain chain = this.chains.Single(x => x.Contains(target));

            return chain.Execute(target);
        }
    }
}
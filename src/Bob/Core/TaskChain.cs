using System.Collections.Generic;
using System.Linq;

namespace Bob.Core
{
    public class TaskChain
    {
        private readonly List<Task> items;

        public TaskChain()
        {
            this.items = new List<Task>();
        }

        public void Add(Task task)
        {
            this.items.Add(task);
        }

        public bool Contains(string target)
        {
            return this.items.Any(x => x.Name == target);
        }

        public TaskResult Execute()
        {
            foreach (Task item in this.items)
            {
                if (item.Execute() == TaskResult.Unsuccessful)
                {
                    return TaskResult.Unsuccessful;
                }
            }

            return TaskResult.Successful;
        }

        public TaskResult Execute(string target)
        {
            foreach (Task item in this.items)
            {
                if (item.Execute() == TaskResult.Unsuccessful)
                {
                    return TaskResult.Unsuccessful;
                }

                if (item.Name == target)
                {
                    return TaskResult.Successful;
                }
            }

            return TaskResult.Successful;
        }
    }
}
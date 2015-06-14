using System;
using System.Collections.Generic;

namespace Bob.Core
{
    public class TaskFunctionEnumerator : Task
    {
        private readonly string name;
        private readonly Func<IEnumerable<ITask>> factory;

        public TaskFunctionEnumerator(string name, Func<IEnumerable<ITask>> factory)
        {
            this.name = name;
            this.factory = factory;
        }

        public static Task Create(object instance)
        {
            Delegate function = instance as Delegate;

            if (function != null)
            {
                if (function.Method.GetParameters().Length > 0)
                {
                    return null;
                }

                if (function.Method.ReturnType != typeof(IEnumerable<ITask>))
                {
                    return null;
                }

                return new TaskFunctionEnumerator(function.Method.Name, (Func<IEnumerable<ITask>>)Delegate.CreateDelegate(typeof(Func<IEnumerable<ITask>>), function.Target, function.Method));
            }

            return null;
        }

        public string Name
        {
            get { return this.name; }
        }

        public TaskResult Execute()
        {
            foreach (ITask task in this.factory.Invoke())
            {
                if (task.Execute() == TaskResult.Unsuccessful)
                {
                    return TaskResult.Unsuccessful;
                }
            }

            return TaskResult.Successful;
        }
    }
}
using System;
using System.Reflection;

namespace Bob.Core
{
    public class TaskFunction : Task
    {
        private readonly string name;
        private readonly Func<ITask> factory;

        public TaskFunction(string name, Func<ITask> factory)
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

                if (function.Method.ReturnType != typeof(ITask))
                {
                    return null;
                }

                return new TaskFunction(function.Method.Name, (Func<ITask>)Delegate.CreateDelegate(typeof(Func<ITask>), function.Target, function.Method));
            }

            return null;
        }

        public string Name
        {
            get { return this.name; }
        }

        public TaskResult Execute()
        {
            return this.factory.Invoke().Execute();
        }
    }
}

using appOrganizer.Organizer.Data;
using System;

namespace appOrganizer.Organizer.Tasks.KindTasks
{
    class SingleTask : Task
    {
        private int _priority;
        public SingleTask (string title, string textTask, int priority) : base(title, textTask, Task.KindTasks.Single)
        {
            Priority = priority;
        }

        public SingleTask (string task) : base(task)
        {
            string[] arrayTask = task.Split('═');
            Priority = Int32.Parse(arrayTask[4]);
        }

        public override string ToString ()
        {
            string finalString = base.ToString();
            return finalString + "═" + Priority;
        }

        public int Priority
        {
            get { return _priority; }
            set
            {
                if (value < 1 || 9 < value)
                    throw new ArgumentException();

                _priority = value;
            }
        }
    }
}
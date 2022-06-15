using appOrganizer.Organizer.Data;
using System;

namespace appOrganizer.Organizer.Tasks.KindTasks
{
    class RoutineTask : Task
    {
        public RoutineTask (string title, string textTask) : base(title, textTask, Task.KindTasks.Routine)
        {
        }

        public RoutineTask (string task) : base(task)
        {
        }

        public override string ToString ()
        {
            return base.ToString();
        }
    }
}
using System;
using System.Collections.Generic;

namespace appOrganizer.Organizer.Tasks.KindTasks
{
    class RoutineTask : Task
    {
        private List<int> _listRoutineDays;
        public RoutineTask (string title, string textTask, string listRoutineDays) : base(title, textTask, Task.KindTasks.Routine)
        {
            _listRoutineDays = new List<int>();
            SetStringDays(listRoutineDays);
        }

        public RoutineTask (string task) : base(task)
        {
            string[] arrayTask = task.Split('═');

            _listRoutineDays = new List<int>();
            SetStringDays(arrayTask[4]);
        }

        public override string ToString ()
        {
            string final = base.ToString() + "═";

            foreach (int date in _listRoutineDays)
                final += date;

            return final;
        }

        public List<int> ListRoutineDays
        {
            get { return _listRoutineDays; }
        }

        private void SetStringDays (string days)
        {
            foreach (char date in days.ToCharArray())
                _listRoutineDays.Add(Int32.Parse(date.ToString()));
        }
    }
}
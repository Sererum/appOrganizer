using Android.Util;
using appOrganizer.Organizer.Data;
using appOrganizer.Organizer.Tasks.KindTasks;
using System;

namespace appOrganizer.Organizer.Tasks
{
    public class Task
    {
        public enum KindTasks { Single, Routine, Project }
        private KindTasks _kindTask;

        private string _title;
        private string _textTask;

        private bool _isCompleted;

        public Task(string title, string textTask, KindTasks kindTask)
        {
            Title = title;
            TextTask = textTask;
            _kindTask = kindTask;
            Completed = false;
        }

        public Task (string task)
        {
            string[] arrayTask = task.Split('═');
            _kindTask = (KindTasks) Int32.Parse(arrayTask[0]);
            Title = arrayTask[1];
            TextTask = arrayTask[2];
            Completed = Byte.Parse(arrayTask[3]) == 1 ? true : false;
        }

        public override string ToString ()
        {
            return ((int) _kindTask) + "═" + Title + "═" + TextTask + "═" + (Completed ? 1 : 0);
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException();

                _title = Helper.TextToStandart(value);
            }
        }

        public string TextTask
        {
            get { return _textTask; }
            set
            {
                if (value == null || value == "")
                {
                    _textTask = "";
                    return;
                }

                _textTask = Helper.TextToStandart(value);
            }
        }

        public KindTasks KindTask
        {
            get { return _kindTask; }
        }

        public bool Completed
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }

        public static int CompareTo (Task taskOne, Task taskTwo)
        {
            int compare = 0;

            compare += ((taskOne.Completed ? 1 : 0) - (taskTwo.Completed ? 1 : 0)) * State.SortsRate[(int) State.Rate.Complete];
            
            compare += ((taskOne is RoutineTask ? 1 : 0) - (taskTwo is RoutineTask ? 1 : 0)) * - State.SortsRate[(int) State.Rate.Routine];

            if (taskOne is SingleTask && taskTwo is SingleTask)
                compare += ((taskOne as SingleTask).Priority.CompareTo((taskTwo as SingleTask).Priority)) * -State.SortsRate[(int) State.Rate.Priority];

            compare += (taskOne.Title.CompareTo(taskTwo.Title)) * State.SortsRate[(int) State.Rate.Name];

            return compare;
        }
    }
}
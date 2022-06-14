using Android.Util;
using appOrganizer.Organizer.Data;
using System;

namespace appOrganizer.Organizer.Tasks
{
    public class Task
    {
        private string _title;
        private string _textTask;

        private byte _priority;

        private bool _isCompleted = false;

        public Task(string title, string textTask, byte priority = 5)
        {
            Title = title;
            TextTask = textTask;
            Priority = priority;
        }

        public Task (string task)
        {
            string[] arrayTask = task.Split('═');
            _title = arrayTask[0];
            _textTask = arrayTask[1];
            _priority = Byte.Parse(arrayTask[2]);
        }

        public override string ToString ()
        {
            return _title + "═" + _textTask + "═" + _priority;
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

        public byte Priority
        {
            get { return _priority; }
            set
            {
                if (value < 0 || 9 < value)
                    throw new ArgumentOutOfRangeException();

                _priority = value;
            }
        }

        public bool Completed
        {
            get { return _isCompleted; }
            set { _isCompleted = (_isCompleted == false); }
        }

        public int CompareTo (Task task) // must finished
        {
            int compare = 0;

            compare += ((_isCompleted ? 1 : 0) - (task.Completed ? 1 : 0)) * State.SortsRate[(int) State.Rate.Complete];
            compare += (task.Priority == Priority ? 0 : (task.Priority > Priority ? 1 : -1)) * State.SortsRate[(int) State.Rate.Priority];
            compare += (task.Title.CompareTo(Title) * -1) * State.SortsRate[(int) State.Rate.Name];

            return compare;
        }
    }
}
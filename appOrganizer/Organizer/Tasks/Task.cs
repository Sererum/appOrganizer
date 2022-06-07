using System;

namespace appOrganizer.Organizer.Tasks
{
    class Task
    {
        private string _label;
        private string _textTask;
        public Task(string label, string textTask)
        {
            _label = label;
            _textTask = textTask;
        }

        public string Label
        {
            get { return _label; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException();

                _label = value;
            }
        }

        public string TextTask
        {
            get { return _textTask; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException();

                _textTask = value;
            }
        }
    }
}
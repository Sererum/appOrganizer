using System;

namespace appOrganizer.Organizer.Tasks
{
    class Task
    {
        private string _label;
        private string _textTask;

        private byte _priority;

        private Time _timeStart;
        private Time _timeEnd;

        public Task(string label, string textTask, byte priority = 5)
        {
            _label = label;
            _textTask = textTask;
            _priority = priority;
        }

        public Task(string label, string textTask, Time timeStart, byte priority = 5) : this(label, textTask, priority)
        {
            _timeStart = timeStart;
        }

        public Task(string label, string textTask, Time timeStart, Time timeEnd, byte priority = 5) : this(label, textTask, timeStart, priority)
        {
            _timeEnd = timeEnd;
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

        public Time TimeStart
        {
            get { return _timeStart; }
            set
            {
                if (_timeEnd != null && value.IsMoreThan(_timeEnd))
                    throw new TimeoutException();

                _timeStart = value;
            }
        }

        public Time TimeEnd
        {
            get { return _timeEnd; }
            set
            {
                if (TimeStart.IsMoreThan(value))
                    throw new TimeoutException();

                _timeEnd = value;
            }
        }


    }
}
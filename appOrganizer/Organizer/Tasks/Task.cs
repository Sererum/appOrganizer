using System;

namespace appOrganizer.Organizer.Tasks
{
    public class Task
    {
        private string _label;
        private string _textTask;

        private byte _priority;

        private Time _timeStart;
        private Time _timeEnd;

        public Task (string label, string textTask, Time timeStart, Time timeEnd, byte priority = 5)
        {
            _label = label;
            _textTask = textTask;
            _priority = priority;
            _timeStart = timeStart;
            _timeEnd = timeEnd;
        }

        public Task (string label, string textTask, Time timeStart, byte priority = 5) : this(label, textTask, timeStart, new Time("592331123000"), priority)
        { }

        public Task (string label, string textTask, byte priority = 5) : this(label, textTask, new Time("000001012000"), new Time("592331123000"), priority)
        { }

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

        public override string ToString ()
        {
            return _label + "═" + _textTask + "═" + _priority + "═" + _timeStart + "═" + _timeEnd;
        }

        public Task(string task)
        {
            string[] arrayTask = task.Split('═');
            _label = arrayTask[0];
            _textTask = arrayTask[1];
            _priority = Byte.Parse(arrayTask[2]);
            _timeStart = new Time(arrayTask[3]);
            _timeEnd = new Time(arrayTask[4]);
        }
    }
}
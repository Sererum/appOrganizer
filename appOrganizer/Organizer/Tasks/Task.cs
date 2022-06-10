using System;

namespace appOrganizer.Organizer.Tasks
{
    public class Task
    {
        private string _title;
        private string _textTask;

        private byte _priority;

        private Time _timeStart;
        private Time _timeEnd;

        public Task (string title, string textTask, Time timeStart, Time timeEnd, byte priority = 5)
        {
            _title = title;
            _textTask = textTask;
            _priority = priority;
            _timeStart = timeStart;
            _timeEnd = timeEnd;
        }

        public Task (string label, string textTask, Time timeStart, byte priority = 5) : this(label, textTask, timeStart, new Time("000000000000"), priority)
        { }

        public Task (string label, string textTask, byte priority = 5) : this(label, textTask, new Time("000000000000"), new Time("000000000000"), priority)
        { }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException();

                _title = value;
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
                if (value.IsRight() == false || _timeEnd != null && value.IsMoreThan(_timeEnd))
                    throw new TimeoutException();

                _timeStart = value;
            }
        }

        public Time TimeEnd
        {
            get { return _timeEnd; }
            set
            {
                if (value.IsRight() == false || TimeStart.IsMoreThan(value))
                    throw new TimeoutException();

                _timeEnd = value;
            }
        }

        public override string ToString ()
        {
            return _title + "═" + _textTask + "═" + _priority + "═" + _timeStart + "═" + _timeEnd;
        }

        public Task(string task)
        {
            string[] arrayTask = task.Split('═');
            _title = arrayTask[0];
            _textTask = arrayTask[1];
            _priority = Byte.Parse(arrayTask[2]);
            _timeStart = new Time(arrayTask[3]);
            _timeEnd = new Time(arrayTask[4]);
        }
    }
}
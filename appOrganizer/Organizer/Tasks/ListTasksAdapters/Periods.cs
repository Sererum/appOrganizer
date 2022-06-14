using appOrganizer.Organizer.Data;
using static appOrganizer.Organizer.Data.Helper;

namespace appOrganizer.Organizer.Tasks.ListTasksAdapters
{
    public class Periods
    {
        class Period
        {
            public string Name;
            public string Date;
            public ListTasks ListTasks;

            public Period(string name, string date, ListTasks listTasks)
            {
                Name = name;
                Date = date;
                ListTasks = listTasks;
            }
        }

        private Period[] _periods = new Period[6];

        public Periods ()
        {
            _periods[0] = new Period("Today", Helper.DateToString[(int) Helper.GroupDate.Today], State.ListTasksToday);
            _periods[1] = new Period("Tomorrow", Helper.DateToString[(int) Helper.GroupDate.Tomorrow], State.ListTasksTomorrow);
            _periods[2] = new Period("ThisMonth", Helper.DateToString[(int) Helper.GroupDate.ThisMonth], State.ListTasksThisMonth);
            _periods[3] = new Period("NextMonth", Helper.DateToString[(int) Helper.GroupDate.NextMonth], State.ListTasksNextMonth);
            _periods[4] = new Period("Year", Helper.DateToString[(int) Helper.GroupDate.Year], State.ListTasksYear);
            _periods[5] = new Period("Global", Helper.DateToString[(int) Helper.GroupDate.Global], State.ListTasksGlobal);
        }

        public string Name(int position)
        {
            return _periods[position].Name;
        }

        public string Date (int position)
        {
            return _periods[position].Date;
        }

        public string Date (GroupDate date)
        {
            return _periods[(int) date].Date;
        }

        public ListTasks List (GroupDate date)
        {
            return _periods[(int) date].ListTasks;
        }

        public ListTasks List (string name)
        {
            foreach(Period period in _periods)
            {
                if (period.Name == name)
                    return period.ListTasks;
            }
            return null;
        }

        public int Position (ListTasks listTasks)
        {
            for (int i = 0; i < _periods.Length; i++)
            {
                if (_periods[i].ListTasks == listTasks)
                    return i;
            }
            return 0;
        }

        public int Count
        {
            get { return _periods.Length; }
        }

    }
}
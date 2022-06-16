using Android.Util;
using appOrganizer.Organizer.Tasks;
using appOrganizer.Organizer.Tasks.ListTasksAdapters;
using Java.Util;
using System;
using System.Collections.Generic;

namespace appOrganizer.Organizer.Data
{
    public static class State
    {
        public enum Rate { Complete, Routine, Priority, Name };

        public static Dictionary<int, int> SortsRate = new Dictionary<int, int>()
        {
            { (int) Rate.Complete, 8 }, 
            { (int) Rate.Routine, 4 },
            { (int) Rate.Priority, 2 },
            { (int) Rate.Name, 1 }
        };

        private static Periods _periods;
        public static Periods Periods
        {
            get { return _periods; }
            set { _periods = value; }
        }

        private static ListTasks _listTasks;
        private static ListTasks _listRoutine;

        private static ListTasks _listTasksToday;
        private static ListTasks _listTasksTomorrow;
        private static ListTasks _listTasksThisMonth;
        private static ListTasks _listTasksNextMonth;
        private static ListTasks _listTasksYear;
        private static ListTasks _listTasksGlobal;

        public static ListTasks ListTasks
        {
            get { return _listTasks; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listTasks = value;
            }
        }

        public static ListTasks ListRoutine
        {
            get { return _listRoutine; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listRoutine = value;
            }
        }

        public static ListTasks ListTasksToday
        {
            get { return _listTasksToday; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listTasksToday = value;
            }
        }

        public static ListTasks ListTasksTomorrow
        {
            get { return _listTasksTomorrow; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listTasksTomorrow = value;
            }
        }

        public static ListTasks ListTasksThisMonth
        {
            get { return _listTasksThisMonth; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listTasksThisMonth = value;
            }
        }

        public static ListTasks ListTasksNextMonth
        {
            get { return _listTasksNextMonth; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listTasksNextMonth = value;
            }
        }

        public static ListTasks ListTasksYear
        {
            get { return _listTasksYear; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listTasksYear = value;
            }
        }

        public static ListTasks ListTasksGlobal
        {
            get { return _listTasksGlobal; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _listTasksGlobal = value;
            }
        }
    }
}
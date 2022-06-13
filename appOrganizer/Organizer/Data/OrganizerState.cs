using appOrganizer.Organizer.Tasks;
using System;

namespace appOrganizer.Organizer.Data
{
    public static class OrganizerState
    {
        public static readonly bool SortByName = true;

        private static ListTasks _listTasks;

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
    }
}
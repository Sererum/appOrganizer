using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appOrganizer.Organizer.Data
{
    public static class OrganizerState
    {
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
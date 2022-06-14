using Android.App;
using Android.Content;
using Android.Util;
using appOrganizer.Organizer.Tasks.ListTasksAdapters;
using static appOrganizer.Organizer.Data.Helper;

namespace appOrganizer.Organizer.Data
{

    public static class Server
    {
        private static ISharedPreferences _preferences = Application.Context.GetSharedPreferences("Settings", FileCreationMode.Private);
        private static ISharedPreferencesEditor _preferencesEdit = _preferences.Edit();

        public static void LoadData ()
        {
            State.Periods = new Periods();

            State.ListTasksToday = new Tasks.ListTasks(_preferences.GetString(State.Periods.Date(GroupDate.Today), ""));
            State.ListTasksTomorrow = new Tasks.ListTasks(_preferences.GetString(State.Periods.Date(GroupDate.Tomorrow), ""));
            State.ListTasksThisMonth = new Tasks.ListTasks(_preferences.GetString(State.Periods.Date(GroupDate.ThisMonth), ""));
            State.ListTasksNextMonth = new Tasks.ListTasks(_preferences.GetString(State.Periods.Date(GroupDate.NextMonth), ""));
            State.ListTasksYear = new Tasks.ListTasks(_preferences.GetString(State.Periods.Date(GroupDate.Year), ""));
            State.ListTasksGlobal = new Tasks.ListTasks(_preferences.GetString(State.Periods.Date(GroupDate.Global), ""));

            State.Periods = new Periods();

            //State.ListTasksToday = new Tasks.ListTasks("Task A═Warning═9╬Task F═Pass═3");
            State.ListTasks = State.ListTasksToday;
        }

        public static void SaveData ()
        {
            
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Today), State.Periods.List(GroupDate.Today).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Tomorrow), State.Periods.List(GroupDate.Tomorrow).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.ThisMonth), State.Periods.List(GroupDate.ThisMonth).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.NextMonth), State.Periods.List(GroupDate.NextMonth).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Year), State.Periods.List(GroupDate.Year).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Global), State.Periods.List(GroupDate.Global).ToString());

            _preferencesEdit.Commit();
        }
    }
}
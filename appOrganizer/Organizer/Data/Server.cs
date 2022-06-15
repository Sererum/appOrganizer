using Android.App;
using Android.Content;
using Android.Util;
using appOrganizer.Organizer.Tasks;
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

            State.ListTasksToday += new Tasks.ListTasks(_preferences.GetString("UncompleteDayTasks", ""));
            State.ListTasksThisMonth += new Tasks.ListTasks(_preferences.GetString("UncompleteMounthTasks", ""));
            State.ListTasksYear += new Tasks.ListTasks(_preferences.GetString("UncompleteYearTasks", ""));

            State.Periods = new Periods();

            Log.Debug("L____UncompleteDayTasks", _preferences.GetString("UncompleteDayTasks", ""));
            Log.Debug("L_UncompleteMounthTasks", _preferences.GetString("UncompleteMounthTasks", ""));
            Log.Debug("L___UncompleteYearTasks", _preferences.GetString("UncompleteYearTasks", ""));
            Log.Debug("L______________________", State.Periods.List(GroupDate.Today).ToString());
            Log.Debug("L______________________", State.Periods.List(GroupDate.Tomorrow).ToString());
            Log.Debug("L______________________", State.Periods.List(GroupDate.ThisMonth).ToString());
            Log.Debug("L______________________", State.Periods.List(GroupDate.NextMonth).ToString());
            Log.Debug("L______________________", State.Periods.List(GroupDate.Year).ToString());
            Log.Debug("L______________________", State.Periods.List(GroupDate.Global).ToString());

            //State.ListTasksToday = new Tasks.ListTasks("Task A═Warning═9╬Task F═Pass═3");
            State.ListTasks = State.ListTasksToday;
        }

        public static void LoadEmptyData ()
        {
            State.Periods = new Periods();

            State.ListTasksToday = new Tasks.ListTasks("");
            State.ListTasksTomorrow = new Tasks.ListTasks("");
            State.ListTasksThisMonth = new Tasks.ListTasks("");
            State.ListTasksNextMonth = new Tasks.ListTasks("");
            State.ListTasksYear = new Tasks.ListTasks("");
            State.ListTasksGlobal = new Tasks.ListTasks("");

            State.ListTasksToday += new Tasks.ListTasks("");
            State.ListTasksThisMonth += new Tasks.ListTasks("");
            State.ListTasksYear += new Tasks.ListTasks("");

            State.Periods = new Periods();

            State.ListTasks = State.ListTasksToday;
        }

        public static void SaveData ()
        {
            ListTasks uncompleteDayTasks = State.ListTasksToday.CutUncompleteTasks();
            ListTasks uncompleteMounthTasks = State.ListTasksThisMonth.CutUncompleteTasks();
            ListTasks uncompleteYearTasks = State.ListTasksYear.CutUncompleteTasks();

            _preferencesEdit.PutString("UncompleteDayTasks", uncompleteDayTasks.ToString());
            _preferencesEdit.PutString("UncompleteMounthTasks", uncompleteMounthTasks.ToString());
            _preferencesEdit.PutString("UncompleteYearTasks", uncompleteYearTasks.ToString());

            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Today), State.Periods.List(GroupDate.Today).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Tomorrow), State.Periods.List(GroupDate.Tomorrow).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.ThisMonth), State.Periods.List(GroupDate.ThisMonth).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.NextMonth), State.Periods.List(GroupDate.NextMonth).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Year), State.Periods.List(GroupDate.Year).ToString());
            _preferencesEdit.PutString(State.Periods.Date(GroupDate.Global), State.Periods.List(GroupDate.Global).ToString());

            Log.Debug("S____UncompleteDayTasks", uncompleteDayTasks.ToString());
            Log.Debug("S_UncompleteMounthTasks", uncompleteMounthTasks.ToString());
            Log.Debug("S___UncompleteYearTasks", uncompleteYearTasks.ToString());
            Log.Debug("S______________________", State.Periods.List(GroupDate.Today).ToString());
            Log.Debug("S______________________", State.Periods.List(GroupDate.Tomorrow).ToString());
            Log.Debug("S______________________", State.Periods.List(GroupDate.ThisMonth).ToString());
            Log.Debug("S______________________", State.Periods.List(GroupDate.NextMonth).ToString());
            Log.Debug("S______________________", State.Periods.List(GroupDate.Year).ToString());
            Log.Debug("S______________________", State.Periods.List(GroupDate.Global).ToString());

            _preferencesEdit.Commit();
        }
    }
}
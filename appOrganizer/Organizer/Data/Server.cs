using Android.App;
using Android.Content;

namespace appOrganizer.Organizer.Data
{
    public static class Server
    {
        private static ISharedPreferences _preferences = Application.Context.GetSharedPreferences("Settings", FileCreationMode.Private);
        private static ISharedPreferencesEditor _preferencesEdit = _preferences.Edit();
        public static void SaveData ()
        {
            _preferencesEdit.PutString("ListTasks", OrganizerState.ListTasks.ToString());

            _preferencesEdit.Commit();
        }

        public static void LoadData ()
        {
            // OrganaizerState.ListTasks = new Tasks.ListTasks(_preferences.GetString("ListTasks", ""));
            OrganizerState.ListTasks = new Tasks.ListTasks("Task═Text═5═000001012000═592331123000╬Task2═Text═5═000001012000═592331123000");
            //OrganaizerState.ListTasks = new Tasks.ListTasks("");
        }
    }
}
using Android.OS;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Tasks;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class ListTasksFragment : AndroidX.Fragment.App.Fragment
    {
        private ListView TaskList;

        private Android.App.Activity _activityContext;
 
        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.list_tasks_fragment_layout, container, false);

            string[] tasks = { "task1", "task2", "task3" };

            TaskList = view.FindViewById<ListView>(Resource.Id.TasksList);
            TaskArrayAdapter adapter = new TaskArrayAdapter(_activityContext, tasks);
            TaskList.Adapter = adapter;

            return view;
        }
    }
}
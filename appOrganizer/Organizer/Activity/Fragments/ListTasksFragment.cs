using Android.OS;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;
using appOrganizer.Organizer.Tasks;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class ListTasksFragment : AndroidX.Fragment.App.Fragment
    {
        private ListView TaskList;
        private Android.App.Activity _context;

        public ListTasksFragment(Android.App.Activity context)
        {
            _context = context;
        }

        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.list_tasks_fragment_layout, container, false);

            TaskList = view.FindViewById<ListView>(Resource.Id.TasksList);
            ListTasksArrayAdapter adapter = new ListTasksArrayAdapter(_context); // Могут возникнуть ошибки из-за null
            TaskList.Adapter = adapter;

            return view;
        }
    }
}
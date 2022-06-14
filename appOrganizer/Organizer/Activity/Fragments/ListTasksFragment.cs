using Android.OS;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;
using appOrganizer.Organizer.Tasks;
using appOrganizer.Organizer.Tasks.ListTasksAdapters;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class ListTasksFragment : Fragment
    {
        private Spinner DateListSpinner;
        private ListView TaskListView;
        private Android.App.Activity _context;

        public ListTasksFragment (Android.App.Activity context)
        {
            _context = context;
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.list_tasks_fragment_layout, container, false);

            DateListSpinner = view.FindViewById<Spinner>(Resource.Id.DateListSpinner);
            DateListSpinner.Adapter = new DateListArrayAdapter(_context);
            DateListSpinner.ItemSelected += delegate
            {
                State.ListTasks = State.Periods.List((string) DateListSpinner.SelectedItem);
                (_context as MainActivity).UpdateFragment();
            };

            TaskListView = view.FindViewById<ListView>(Resource.Id.TasksList);
            UpdateListTasks();

            return view;
        }

        public void UpdateListTasks ()
        {
            TaskListView.Adapter = new ListTasksArrayAdapter(_context);
            DateListSpinner.SetSelection(State.Periods.Position(State.ListTasks));
        }
    }
}
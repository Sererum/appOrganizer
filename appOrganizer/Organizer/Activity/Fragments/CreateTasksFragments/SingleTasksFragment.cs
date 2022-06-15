using Android.OS;
using Android.Views;
using Android.Widget;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace appOrganizer.Organizer.Activity.Fragments.CreateTasksFragments
{
    public class SingleTasksFragment : Fragment
    {
        private Spinner _prioritySpinner;

        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_create_single_task, container, false);

            _prioritySpinner = view.FindViewById<Spinner>(Resource.Id.PrioritySpinner);
            _prioritySpinner.SetSelection(4);

            return view;
        }

        public int SpinnerSelected
        {
            get 
            {
                int change = (int) _prioritySpinner.SelectedItemId + 1;
                _prioritySpinner.SetSelection(4);
                return change; 
            }
            set { _prioritySpinner.SetSelection(value - 1); }
        }
    }
}
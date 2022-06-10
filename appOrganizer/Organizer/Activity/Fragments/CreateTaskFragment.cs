using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class CreateTaskFragment : Fragment
    {
        private MainActivity MainActivity;
        public CreateTaskFragment(MainActivity activity)
        {
            MainActivity = activity;
        }

        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.create_task_layout, container, false);

            EditText title = view.FindViewById<EditText>(Resource.Id.TitleTaskEditText);
            EditText textTask = view.FindViewById<EditText>(Resource.Id.TextTaskEditText);
            Spinner prioritySpinner = view.FindViewById<Spinner>(Resource.Id.PrioritySpinner);

            prioritySpinner.SetSelection(4);

            view.FindViewById<Button>(Resource.Id.OkCreateTaskButton).Click += delegate
            {
                if (title.Text.Length == 0)
                    return;

                OrganizerState.ListTasks.AddTask(title.Text, textTask.Text);
                MainActivity.LoadLastState();

                title.Text = "";
                textTask.Text = "";
                prioritySpinner.SetSelection(4);
            };

            view.FindViewById<Button>(Resource.Id.CancelCreateTaskButton).Click += delegate
            {
                MainActivity.LoadLastState();
            };

            return view;
        }
    }
}
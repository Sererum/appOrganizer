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

        private bool _isEditTask;
        private int _indexEditTask;

        private EditText _title;
        private EditText _textTask;
        private Spinner _prioritySpinner;

        public CreateTaskFragment(MainActivity activity)
        {
            MainActivity = activity;
        }

        public void EditTask(int indexTask)
        {
            _title.Text = OrganizerState.ListTasks[indexTask].Title;
            _textTask.Text = OrganizerState.ListTasks[indexTask].TextTask;
            _prioritySpinner.SetSelection(OrganizerState.ListTasks[indexTask].Priority - 1);
            _isEditTask = true;
            _indexEditTask = indexTask;
        }

        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.create_task_layout, container, false);

            _title = view.FindViewById<EditText>(Resource.Id.TitleTaskEditText);
            _textTask = view.FindViewById<EditText>(Resource.Id.TextTaskEditText);
            _prioritySpinner = view.FindViewById<Spinner>(Resource.Id.PrioritySpinner);

            _prioritySpinner.SetSelection(4);

            view.FindViewById<Button>(Resource.Id.OkCreateTaskButton).Click += delegate
            {
                if (_title.Text.Length == 0)
                    return;

                if (_isEditTask == true)
                    OrganizerState.ListTasks.DeleteTask(_indexEditTask);
                    
                OrganizerState.ListTasks.AddTask(_title.Text, _textTask.Text);

                MainActivity.LoadLastState();

                _title.Text = "";
                _textTask.Text = "";
                _prioritySpinner.SetSelection(4);
            };

            view.FindViewById<Button>(Resource.Id.CancelCreateTaskButton).Click += delegate
            {
                MainActivity.LoadLastState();
            };

            return view;
        }
    }
}
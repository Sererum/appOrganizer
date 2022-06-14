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
            _title.Text = State.ListTasks[indexTask].Title;
            _textTask.Text = State.ListTasks[indexTask].TextTask;
            _prioritySpinner.SetSelection(State.ListTasks[indexTask].Priority - 1);
            _isEditTask = true;
            _indexEditTask = indexTask;
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.create_task_fragment, container, false);

            _title = view.FindViewById<EditText>(Resource.Id.TitleTaskEditText);
            _textTask = view.FindViewById<EditText>(Resource.Id.TextTaskEditText);
            _prioritySpinner = view.FindViewById<Spinner>(Resource.Id.PrioritySpinner);

            _prioritySpinner.SetSelection(4);

            view.FindViewById<Button>(Resource.Id.OkCreateTaskButton).Click += delegate
            {
                if (Helper.TextToStandart(_title.Text).Length == 0)
                {
                    _title.Text = "";
                    return;
                }
                    
                if (_isEditTask == true)
                    State.ListTasks.DeleteTask(_indexEditTask);
                    
                State.ListTasks.AddTask(new Tasks.Task(
                    title: _title.Text, 
                    textTask: _textTask.Text, 
                    priority: (byte) (_prioritySpinner.SelectedItemId + 1))
                    );

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
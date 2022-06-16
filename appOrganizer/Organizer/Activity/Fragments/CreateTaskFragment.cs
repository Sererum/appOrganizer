using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Activity.Fragments.CreateTasksFragments;
using appOrganizer.Organizer.Data;
using appOrganizer.Organizer.Tasks;
using appOrganizer.Organizer.Tasks.KindTasks;
using Fragment = AndroidX.Fragment.App.Fragment;
using FragmentTransaction = AndroidX.Fragment.App.FragmentTransaction;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class CreateTaskFragment : Fragment
    {
        private MainActivity MainActivity;

        private ProjectTasksFragment ProjectTasksFragment;
        private RoutineTasksFragment RoutineTasksFragment;
        private SingleTasksFragment SingleTasksFragment;

        private Fragment CurrentFragment;

        private bool _isEditTask;
        private int _indexEditTask;

        private EditText _titleEditText;
        private EditText _textTaskEditText;

        private RadioGroup _kindTasksRadio;
        private RadioButton _singleRadioButton;
        private RadioButton _routineRadioButton;
        private RadioButton _projectRadioButton;

        public CreateTaskFragment(MainActivity activity)
        {
            MainActivity = activity;
        }

        private void InitFragments ()
        {
            ProjectTasksFragment = new ProjectTasksFragment();
            RoutineTasksFragment = new RoutineTasksFragment();
            SingleTasksFragment = new SingleTasksFragment();

            CurrentFragment = SingleTasksFragment; // Start fragment

            var FragmentTransaction = ChildFragmentManager.BeginTransaction();

            Fragment[] fragments = {
                ProjectTasksFragment, RoutineTasksFragment, SingleTasksFragment
            };

            foreach (Fragment fragment in fragments)
                FragmentTransaction.Add(Resource.Id.KindFragmentLayout, fragment).Hide(fragment);

            FragmentTransaction.Commit();

            FragmentTransaction.Show(CurrentFragment);
        }

        private void ShowFragment (Fragment fragment)
        {
            if (fragment.IsVisible)
                return;

            var FragmentTransaction = ChildFragmentManager.BeginTransaction();

            FragmentTransaction.Hide(CurrentFragment);
            FragmentTransaction.Show(fragment);
            CurrentFragment = fragment;

            FragmentTransaction.AddToBackStack(null);
            FragmentTransaction.Commit();
        }

        public void EditTask(int indexTask)
        {
            _titleEditText.Text = State.ListTasks[indexTask].Title;
            _textTaskEditText.Text = State.ListTasks[indexTask].TextTask;

            switch (State.ListTasks[indexTask].KindTask)
            {
                case Task.KindTasks.Single:
                {
                    SingleTasksFragment.SpinnerSelected = (State.ListTasks[indexTask] as SingleTask).Priority;
                    break;
                }
                case Task.KindTasks.Routine:
                {
                    _routineRadioButton.Checked = true;
                    break;
                }
                case Task.KindTasks.Project:
                {
                    _projectRadioButton.Checked = true;
                    break;
                }
            }


            _isEditTask = true;
            _indexEditTask = indexTask;
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_create_task, container, false);

            _titleEditText = view.FindViewById<EditText>(Resource.Id.TitleTaskEditText);
            _textTaskEditText = view.FindViewById<EditText>(Resource.Id.TextTaskEditText);
            _kindTasksRadio = view.FindViewById<RadioGroup>(Resource.Id.KindTasksRadioGroup);

            _singleRadioButton = view.FindViewById<RadioButton>(Resource.Id.SingleTaskRadioButton);
            _routineRadioButton = view.FindViewById<RadioButton>(Resource.Id.RoutineTaskRadioButton);
            _projectRadioButton = view.FindViewById<RadioButton>(Resource.Id.ProjectTaskRadioButton);

            view.FindViewById<Button>(Resource.Id.OkCreateTaskButton).Click += delegate { OkTaskButtonEvent(); };
            view.FindViewById<Button>(Resource.Id.CancelCreateTaskButton).Click += delegate { MainActivity.LoadLastState(); };

            _kindTasksRadio.CheckedChange += delegate { RadioGroupCheckedChangeEvent(); };

            return view;
        }

        private void RadioGroupCheckedChangeEvent ()
        {
            switch (_kindTasksRadio.CheckedRadioButtonId)
            {
                case Resource.Id.SingleTaskRadioButton:
                {
                    ShowFragment(SingleTasksFragment);
                    break;
                }
                case Resource.Id.RoutineTaskRadioButton:
                {
                    ShowFragment(RoutineTasksFragment);
                    break;
                }
                case Resource.Id.ProjectTaskRadioButton:
                {
                    ShowFragment(ProjectTasksFragment);
                    break;
                }
            }
        }

        private void OkTaskButtonEvent ()
        {
            int radioId = _kindTasksRadio.CheckedRadioButtonId;

            if (Helper.TextToStandart(_titleEditText.Text).Length == 0)
            {
                _titleEditText.Text = "";
                return;
            }

            if (_isEditTask == true)
            {
                if (radioId == Resource.Id.RoutineTaskRadioButton)
                    State.ListRoutine.DeleteTask(State.ListTasks[_indexEditTask]);
                
                State.ListTasks.DeleteTask(_indexEditTask);
                _isEditTask = false;
            }

            if (radioId == Resource.Id.SingleTaskRadioButton)
                State.ListTasks.AddTask(new SingleTask(
                        title: _titleEditText.Text,
                        textTask: _textTaskEditText.Text,
                        priority: SingleTasksFragment.SpinnerSelected
                        ));

            if (radioId == Resource.Id.RoutineTaskRadioButton)
            {
                RoutineTask routine = new RoutineTask(
                        title: _titleEditText.Text,
                        textTask: _textTaskEditText.Text,
                        listRoutineDays: RoutineTasksFragment.ListRoutineDays
                        );
                State.ListRoutine.AddTask(routine);
                Server.AddRoutines();
            }

            if (radioId == Resource.Id.ProjectTaskRadioButton)
                return;

            MainActivity.LoadLastState();

            _titleEditText.Text = "";
            _textTaskEditText.Text = "";
            _singleRadioButton.Checked = true;
        }

        public override void OnViewCreated (View view, Bundle savedInstanceState)
        {
            InitFragments();
            base.OnViewCreated(view, savedInstanceState);
        }
    }
}
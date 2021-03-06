using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using appOrganizer.Organizer.Activity.Fragments;
using appOrganizer.Organizer.Data;
using System;
using Fragment = AndroidX.Fragment.App.Fragment;
using FragmentTransaction = AndroidX.Fragment.App.FragmentTransaction;

namespace appOrganizer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button CalendarButton;
        private Button ScheduleButton;
        private Button ListTasksButton;
        private Button TimerButton;
        private Button AccountButton;

        private Button CreateTaskButton;

        private CalendarFragment CalendarFragment;
        private ScheduleFragment ScheduleFragment;
        private ListTasksFragment ListTasksFragment;
        private TimerFragment TimerFragment;
        private AccountFragment AccountFragment;

        private CreateTaskFragment CreateTaskFragment;

        private Fragment CurrentFragment;

        private ViewStates LastAddTaskButtonState = ViewStates.Visible;
        private Fragment LastFragment;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Server.LoadData();
            Server.LoadEmptyData();

            InitFragments(savedInstanceState);
            InitButtons();
        }

        private void InitFragments (Bundle savedInstanceState)
        {
            CalendarFragment = new CalendarFragment();
            ScheduleFragment = new ScheduleFragment();
            ListTasksFragment = new ListTasksFragment(this);
            TimerFragment = new TimerFragment();
            AccountFragment = new AccountFragment();

            CreateTaskFragment = new CreateTaskFragment(this);

            CurrentFragment = ListTasksFragment; // Start fragment

            var FragmentTransaction = SupportFragmentManager.BeginTransaction();

            if (savedInstanceState == null)
            {
                Fragment[] fragments = { 
                    CalendarFragment, ScheduleFragment, ListTasksFragment, TimerFragment, AccountFragment, CreateTaskFragment 
                };
                
                foreach (Fragment fragment in fragments)
                    FragmentTransaction.Add(Resource.Id.FragmentLayout, fragment).Hide(fragment);

                FragmentTransaction.Commit();
            }

            FragmentTransaction.Show(CurrentFragment);
        }

        private void InitButtons ()
        {
            CalendarButton = FindViewById<Button>(Resource.Id.CalendarButton);
            ScheduleButton = FindViewById<Button>(Resource.Id.ScheduleButton);
            ListTasksButton = FindViewById<Button>(Resource.Id.ListTasksButton);
            TimerButton = FindViewById<Button>(Resource.Id.TimerButton);
            AccountButton = FindViewById<Button>(Resource.Id.AccountButton);

            CreateTaskButton = FindViewById<Button>(Resource.Id.AddTaskButton);

            CalendarButton.Click += delegate { ButtonEvent(ViewStates.Gone, CalendarFragment); };
            ScheduleButton.Click += delegate { ButtonEvent(ViewStates.Gone, ScheduleFragment); };
            ListTasksButton.Click += delegate { ButtonEvent(ViewStates.Visible, ListTasksFragment); };
            TimerButton.Click += delegate { ButtonEvent(ViewStates.Gone, TimerFragment); };
            AccountButton.Click += delegate { ButtonEvent(ViewStates.Gone, AccountFragment); };
            CreateTaskButton.Click += delegate { ButtonEvent(ViewStates.Gone, CreateTaskFragment); };
        }

        public void ButtonEvent(ViewStates visibleState, Fragment fragment)
        {
            SaveLastState();
            CreateTaskButton.Visibility = visibleState;
            ShowFragment(fragment);
        }

        private void ShowFragment (Fragment fragment, bool update = false)
        {
            if (fragment.IsVisible && update == false)
                return;

            var FragmentTransaction = SupportFragmentManager.BeginTransaction();

            FragmentTransaction.Hide(CurrentFragment);
            FragmentTransaction.Show(fragment);
            CurrentFragment = fragment;

            if (fragment == ListTasksFragment)
                ListTasksFragment.UpdateListTasks();

            FragmentTransaction.AddToBackStack(null);
            FragmentTransaction.Commit();
        }

        private void SaveLastState ()
        {
            LastAddTaskButtonState = CreateTaskButton.Visibility;
            LastFragment = CurrentFragment;
        }

        public void LoadLastState ()
        {
            if (LastFragment == null)
                return;

            CreateTaskButton.Visibility = LastAddTaskButtonState;
            ShowFragment(LastFragment);
        }

        public void EditTask(int index)
        {
            SaveLastState();
            CreateTaskButton.Visibility = ViewStates.Gone;
            (CreateTaskFragment as CreateTaskFragment).EditTask(index);
            ShowFragment(CreateTaskFragment);
        }

        public void DeleteTask (int index)
        {
            State.ListTasks.DeleteTask(index);
            UpdateFragment();
        }

        public void UpdateFragment()
        {
            ShowFragment(CurrentFragment, true);
        }

        public override void OnBackPressed ()
        {
            LoadLastState();
        }

        protected override void OnStop ()
        {
            Server.SaveData();
            base.OnStop();
        }
    }
}
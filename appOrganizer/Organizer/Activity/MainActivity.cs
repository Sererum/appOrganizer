using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using appOrganizer.Organizer.Activity.Fragments;
using appOrganizer.Organizer.Data;

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

        private Button AddTaskButton;

        private Fragment CalendarFragment;
        private Fragment ScheduleFragment;
        private Fragment ListTasksFragment;
        private Fragment TimerFragment;
        private Fragment AccountFragment;

        private Fragment CreateTaskFragment;

        private Fragment CurrentFragment;

        private ViewStates LastAddTaskButtonState = ViewStates.Visible;
        private Fragment LastFragment;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            CalendarButton = FindViewById<Button>(Resource.Id.CalendarButton);
            ScheduleButton = FindViewById<Button>(Resource.Id.ScheduleButton);
            ListTasksButton = FindViewById<Button>(Resource.Id.ListTasksButton);
            TimerButton = FindViewById<Button>(Resource.Id.TimerButton);
            AccountButton = FindViewById<Button>(Resource.Id.AccountButton);

            AddTaskButton = FindViewById<Button>(Resource.Id.AddTaskButton);

            Server.LoadData();

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

            CurrentFragment = ListTasksFragment;

            var FragmentTransaction = SupportFragmentManager.BeginTransaction();

            if (savedInstanceState == null)
            {
                FragmentTransaction.Add(Resource.Id.FragmentLayout, CalendarFragment).Hide(CalendarFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, ScheduleFragment).Hide(ScheduleFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, ListTasksFragment).Hide(ListTasksFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, TimerFragment).Hide(TimerFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, AccountFragment).Hide(AccountFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, CreateTaskFragment).Hide(CreateTaskFragment);
                FragmentTransaction.Commit();
            }

            FragmentTransaction.Show(CurrentFragment);
        }

        private void InitButtons ()
        {
            CalendarButton.Click += delegate
            {
                SaveLastState();

                AddTaskButton.Visibility = ViewStates.Gone;
                ShowFragment(CalendarFragment);
            };

            ScheduleButton.Click += delegate
            {
                SaveLastState();

                AddTaskButton.Visibility = ViewStates.Gone;
                ShowFragment(ScheduleFragment);
            };

            ListTasksButton.Click += delegate
            {
                SaveLastState();

                AddTaskButton.Visibility = ViewStates.Visible;
                ShowFragment(ListTasksFragment);
            };

            TimerButton.Click += delegate
            {
                SaveLastState();

                AddTaskButton.Visibility = ViewStates.Gone;
                ShowFragment(TimerFragment);
            };

            AccountButton.Click += delegate
            {
                SaveLastState();

                AddTaskButton.Visibility = ViewStates.Gone;
                ShowFragment(AccountFragment);
            };

            AddTaskButton.Click += delegate
            {
                SaveLastState();

                AddTaskButton.Visibility = ViewStates.Gone;
                ShowFragment(CreateTaskFragment);
            };
        }

        private void ShowFragment (Fragment fragment)
        {
            if (fragment.IsVisible)
                return;

            var FragmentTransaction = SupportFragmentManager.BeginTransaction();

            FragmentTransaction.Hide(CurrentFragment);
            FragmentTransaction.Show(fragment);
            CurrentFragment = fragment;
            
            FragmentTransaction.AddToBackStack(null);
            FragmentTransaction.Commit();
        }

        private void SaveLastState ()
        {
            LastAddTaskButtonState = AddTaskButton.Visibility;
            LastFragment = CurrentFragment;
            Log.Debug("SaveLastState", LastAddTaskButtonState + " " + LastFragment);
        }

        public void LoadLastState ()
        {
            AddTaskButton.Visibility = LastAddTaskButtonState;
            if (LastFragment != null)
                ShowFragment(LastFragment);

            Log.Debug("LoadLastState", LastAddTaskButtonState + " " + LastFragment);
        }

        public override void OnBackPressed ()
        {
            LoadLastState();
        }
    }
}
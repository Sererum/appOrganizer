using Android.App;
using Android.OS;
using Android.Util;
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

        private Fragment CalendarFragment;
        private Fragment ScheduleFragment;
        private Fragment ListTasksFragment;
        private Fragment TimerFragment;
        private Fragment AccountFragment;

        private Fragment CurrentFragment;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            CalendarButton = FindViewById<Button>(Resource.Id.CalendarButton);
            ScheduleButton = FindViewById<Button>(Resource.Id.ScheduleButton);
            ListTasksButton = FindViewById<Button>(Resource.Id.ListTasksButton);
            TimerButton = FindViewById<Button>(Resource.Id.TimerButton);
            AccountButton = FindViewById<Button>(Resource.Id.AccountButton);

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

            CurrentFragment = ListTasksFragment;

            var FragmentTransaction = SupportFragmentManager.BeginTransaction();

            if (savedInstanceState == null)
            {
                FragmentTransaction.Add(Resource.Id.FragmentLayout, CalendarFragment).Hide(CalendarFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, ScheduleFragment).Hide(ScheduleFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, ListTasksFragment).Hide(ListTasksFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, TimerFragment).Hide(TimerFragment);
                FragmentTransaction.Add(Resource.Id.FragmentLayout, AccountFragment).Hide(AccountFragment);
                FragmentTransaction.Commit();
            }

            FragmentTransaction.Show(CurrentFragment);
        }

        private void InitButtons ()
        {
            CalendarButton.Click += delegate
            {
                ShowFragment(CalendarFragment);
            };
            ScheduleButton.Click += delegate
            {
                ShowFragment(ScheduleFragment);
            };
            ListTasksButton.Click += delegate
            {
                ShowFragment(ListTasksFragment);
            };
            TimerButton.Click += delegate
            {
                ShowFragment(TimerFragment);
            };
            AccountButton.Click += delegate
            {
                ShowFragment(AccountFragment);
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
    }
}
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Util;
using System.Collections.Generic;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace appOrganizer.Organizer.Activity.Fragments.CreateTasksFragments
{
    public class RoutineTasksFragment : Fragment
    {
        private RadioButton MondayRadio;
        private RadioButton TuesdayRadio;
        private RadioButton WednesdayRadio;
        private RadioButton ThursdayRadio;
        private RadioButton FridayRadio;
        private RadioButton SaturdayRadio;
        private RadioButton SundayRadio;

        private List<int> _listRoutineDays;

        public override void OnCreate (Bundle savedInstanceState)
        {
            _listRoutineDays = new List<int>();
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_create_routine_task, container, false);

            MondayRadio = view.FindViewById<RadioButton>(Resource.Id.MondayRadioButton);
            TuesdayRadio = view.FindViewById<RadioButton>(Resource.Id.TuesdayRadioButton);
            WednesdayRadio = view.FindViewById<RadioButton>(Resource.Id.WednesdayRadioButton);
            ThursdayRadio = view.FindViewById<RadioButton>(Resource.Id.ThursdayRadioButton);
            FridayRadio = view.FindViewById<RadioButton>(Resource.Id.FridayRadioButton);
            SaturdayRadio = view.FindViewById<RadioButton>(Resource.Id.SaturdayRadioButton);
            SundayRadio = view.FindViewById<RadioButton>(Resource.Id.SundayRadioButton);

            SundayRadio.CheckedChange += delegate { RadioEvent(SundayRadio, 1); };
            MondayRadio.CheckedChange += delegate { RadioEvent(MondayRadio, 2); };
            TuesdayRadio.CheckedChange += delegate { RadioEvent(TuesdayRadio, 3); };
            WednesdayRadio.CheckedChange += delegate { RadioEvent(WednesdayRadio, 4); };
            ThursdayRadio.CheckedChange += delegate { RadioEvent(ThursdayRadio, 5); };
            FridayRadio.CheckedChange += delegate { RadioEvent(FridayRadio, 6); };
            SaturdayRadio.CheckedChange += delegate { RadioEvent(SaturdayRadio, 7); };

            return view;
        }

        public string ListRoutineDays
        {
            get 
            {
                string final = "";
                foreach (int date in _listRoutineDays)
                    final += date;

                SundayRadio.Checked = false;
                MondayRadio.Checked = false;
                TuesdayRadio.Checked = false;
                WednesdayRadio.Checked = false;
                ThursdayRadio.Checked = false;
                FridayRadio.Checked = false;
                SaturdayRadio.Checked = false;
                _listRoutineDays = new List<int>();

                return final; 
            }
        }

        private void RadioEvent (RadioButton button, int day)
        {
            if (button.Checked)
                _listRoutineDays.Add(day);
            else
                _listRoutineDays.Remove(day);
        }
    }
}
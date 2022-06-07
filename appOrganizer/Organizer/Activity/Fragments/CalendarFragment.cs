using Android.App;
using Android.OS;
using Android.Views;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class CalendarFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.calendar_fragment_layout, container, false);
            return view;
        }
    }
}
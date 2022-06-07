using Android.App;
using Android.OS;
using Android.Views;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class TimerFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.timer_fragment_layout, container, false);
        }
    }
}
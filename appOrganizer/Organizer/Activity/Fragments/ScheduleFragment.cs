using Android.App;
using Android.OS;
using Android.Views;

using Fragment = AndroidX.Fragment.App.Fragment;

namespace appOrganizer.Organizer.Activity.Fragments
{
    public class ScheduleFragment : Fragment
    {
        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_schedule, container, false);
        }
    }
}
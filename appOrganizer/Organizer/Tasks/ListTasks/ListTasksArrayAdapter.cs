using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;
using System;

namespace appOrganizer.Organizer.Tasks
{
    class ListTasksArrayAdapter : BaseAdapter<Task>
    {
        private ListTasks _listTasks;

        private Android.App.Activity _context;

        public ListTasksArrayAdapter(Android.App.Activity context) : base()
        {
            _listTasks = OrganizerState.ListTasks;
            _context = context;
        }

        public override Task this[int position]
        {
            get { return _listTasks[position]; }
            
        }

        public override int Count
        {
            get { return _listTasks.Count; }
        }

        public override long GetItemId (int position)
        {
            return position;
        }

        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.task_item_list, null);

            view.FindViewById<TextView>(Resource.Id.NameTaskTextView).Text = _listTasks[position].Title;

            return view;
        }
    }
}
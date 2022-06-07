using Android.Views;
using Android.Widget;
using System;

namespace appOrganizer.Organizer.Tasks
{
    class TaskArrayAdapter : BaseAdapter<string>
    {
        private string[] _nameTasks;

        private Android.App.Activity _context;
        public override string this[int position] => throw new NotImplementedException();

        public TaskArrayAdapter(Android.App.Activity context, string[] nameTasks) : base()
        {
            _nameTasks = nameTasks;
            _context = context;
        }

        public override int Count
        {
            get { return _nameTasks.Length; }
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

            view.FindViewById<TextView>(Resource.Id.NameTaskTextView).Text = _nameTasks[position];

            return view;
        }
    }
}
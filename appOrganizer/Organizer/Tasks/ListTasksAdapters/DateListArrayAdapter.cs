using Android.Util;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;
using System;

using static appOrganizer.Organizer.Data.Helper;

namespace appOrganizer.Organizer.Tasks.ListTasksAdapters
{
    class DateListArrayAdapter : BaseAdapter<string>
    {
        private Android.App.Activity _context;

        public DateListArrayAdapter(Android.App.Activity context)
        {
            _context = context;
        }

        class ViewHolder : Java.Lang.Object
        {
            public TextView NamePeriodView;
            public TextView DatePeriodView;
        }

        public override string this[int position]
        {
            get { return State.Periods.Name(position); }
        }

        public override int Count
        {
            get { return State.Periods.Count; }
        }

        public override long GetItemId (int position)
        {
            return position;
        }

        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            ViewHolder holder;
            View view = convertView;

            var a =  DateTime.Now;

            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.date_list_item, null);
                holder = new ViewHolder();
                holder.NamePeriodView = view.FindViewById<TextView>(Resource.Id.NamePeriodTextView);
                holder.DatePeriodView = view.FindViewById<TextView>(Resource.Id.DatePeriodTextView);
                view.SetTag(Resource.String.key_DateListAA, holder);
            }
            else
            {
                holder = (ViewHolder) view.GetTag(Resource.String.key_DateListAA);
            }

            holder.NamePeriodView.Text = State.Periods.Name(position);
            holder.DatePeriodView.Text = State.Periods.Date(position);

            return view;
        }

        private void InitOnClickView ()
        {
            
        }
    }
}
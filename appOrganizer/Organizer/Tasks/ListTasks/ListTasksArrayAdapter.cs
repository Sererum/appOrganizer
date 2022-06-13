using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;
using System;

namespace appOrganizer.Organizer.Tasks
{
    class ListTasksArrayAdapter : BaseAdapter<Task>
    {
        private Android.App.Activity _context;

        public ListTasksArrayAdapter(Android.App.Activity context) : base()
        {
            _context = context;
        }

        class ViewHolder : Java.Lang.Object
        {
            public TextView NameTaskView;
            public TextView TextTaskView;
            public CheckBox CompleteCheckBox;
        }

        public override Task this[int position]
        {
            get { return OrganizerState.ListTasks[position]; }
            
        }

        public override int Count
        {
            get { return OrganizerState.ListTasks.Count; }
        }

        public override long GetItemId (int position)
        {
            return position;
        }

        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            ViewHolder holder;
            View view = convertView;

            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.task_item_list, null);
                holder = new ViewHolder();
                holder.NameTaskView = view.FindViewById<TextView>(Resource.Id.NameTaskTextView);
                holder.TextTaskView = view.FindViewById<TextView>(Resource.Id.TextTaskTextView);
                holder.CompleteCheckBox = view.FindViewById<CheckBox>(Resource.Id.CompleteCheckBox);
                view.SetTag(Resource.String.key_holder, holder);
            }
            else
            {
                holder = (ViewHolder) view.GetTag(Resource.String.key_holder);
            }

            view.LongClick += delegate
            {
                PopupMenu popup = new PopupMenu(_context, view);
                popup.MenuInflater.Inflate(Resource.Menu.task_item_context_menu, popup.Menu);
                popup.Show();

                popup.MenuItemClick += (object sender, PopupMenu.MenuItemClickEventArgs e) =>
                {
                    switch (e.Item.ItemId)
                    {
                        case Resource.Id.edit:
                        {
                            (_context as MainActivity).EditTask(position);
                            break;
                        }
                        case Resource.Id.delete:
                        {
                            (_context as MainActivity).DeleteTask(position);
                            break;
                        }
                    }
                };
            };

            holder.CompleteCheckBox.Checked = OrganizerState.ListTasks[position].Completed;
            ChangeTextStyle(holder, position);

            holder.CompleteCheckBox.CheckedChange += delegate
            {
                if (holder.CompleteCheckBox.Checked == true)
                    OrganizerState.ListTasks[position].Completed = true;
                else
                    OrganizerState.ListTasks[position].Completed = false;

                ChangeTextStyle(holder, position);

                OrganizerState.ListTasks.SortList();
                (_context as MainActivity).UpdateFragment();
            };

            holder.NameTaskView.Text = OrganizerState.ListTasks[position].Title;
            holder.TextTaskView.Text = OrganizerState.ListTasks[position].TextTask;

            return view;
        }

        private void ChangeTextStyle(ViewHolder holder, int position)
        {
            PaintFlags nowPaintFlag = holder.CompleteCheckBox.Checked == true ? PaintFlags.StrikeThruText : PaintFlags.LinearText;

            holder.NameTaskView.PaintFlags = nowPaintFlag;
            holder.TextTaskView.PaintFlags = nowPaintFlag;
        }
    }
}
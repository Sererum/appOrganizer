using Android.Util;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;

namespace appOrganizer.Organizer.Tasks
{
    class ListTasksArrayAdapter : BaseAdapter<Task>
    {
        private Android.App.Activity _context;

        public ListTasksArrayAdapter(Android.App.Activity context) : base()
        {
            _context = context;
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
            View view = convertView;

            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.task_item_list, null);

            view.Click += delegate
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

            view.FindViewById<TextView>(Resource.Id.NameTaskTextView).Text = OrganizerState.ListTasks[position].Title;
            view.FindViewById<TextView>(Resource.Id.TextTaskTextView).Text = OrganizerState.ListTasks[position].TextTask;

            return view;
        }
    }
}
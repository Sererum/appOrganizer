using Android.Content.Res;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using appOrganizer.Organizer.Data;
using appOrganizer.Organizer.Tasks.KindTasks;

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
            public TextView PriorityView;
            public CheckBox CompleteCheckBox;
        }

        public override Task this[int position]
        {
            get { return State.ListTasks[position]; }
        }

        public override int Count
        {
            get { return State.ListTasks.Count; }
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.list_item_task, null);
                holder = new ViewHolder();
                holder.NameTaskView = view.FindViewById<TextView>(Resource.Id.NameTaskTextView);
                holder.TextTaskView = view.FindViewById<TextView>(Resource.Id.TextTaskTextView);
                holder.PriorityView = view.FindViewById<TextView>(Resource.Id.PriorityTextView);
                holder.CompleteCheckBox = view.FindViewById<CheckBox>(Resource.Id.CompleteCheckBox);
                view.SetTag(Resource.String.key_ListTasksAA, holder);
            }
            else
            {
                holder = (ViewHolder) view.GetTag(Resource.String.key_ListTasksAA);
            }

            view.LongClick += delegate { LongClickViewEvent(view, position); };

            InitCheckBox(holder, position);

            holder.NameTaskView.Text = State.ListTasks[position].Title;
            holder.TextTaskView.Text = State.ListTasks[position].TextTask;

            if (State.ListTasks[position] is SingleTask)
            {
                InitPriorityView(holder, position);
            }
            if (State.ListTasks[position] is RoutineTask)
            {
                InitPriorityView(holder, position);
            }

            return view;
        }

        private void ChangeTextStyle(ViewHolder holder, int position)
        {
            PaintFlags nowPaintFlag = holder.CompleteCheckBox.Checked == true ? PaintFlags.StrikeThruText : PaintFlags.LinearText;

            holder.NameTaskView.PaintFlags = nowPaintFlag;
            holder.TextTaskView.PaintFlags = nowPaintFlag;
            holder.PriorityView.PaintFlags = nowPaintFlag;
        }

        private void LongClickViewEvent (View view, int position)
        {
            PopupMenu popup = new PopupMenu(_context, view);
            popup.MenuInflater.Inflate(Resource.Menu.task_item_context_menu, popup.Menu);
            popup.Show();

            popup.MenuItemClick += (object sender, PopupMenu.MenuItemClickEventArgs e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.ListTasksEventEdit:
                    {
                        (_context as MainActivity).EditTask(position);
                        break;
                    }
                    case Resource.Id.ListTasksEventDelete:
                    {
                        (_context as MainActivity).DeleteTask(position);
                        break;
                    }
                }
            };
        }

        private void InitCheckBox (ViewHolder holder, int position)
        {
            holder.CompleteCheckBox.Checked = State.ListTasks[position].Completed;
            ChangeTextStyle(holder, position);

            holder.CompleteCheckBox.CheckedChange += delegate
            {
                if (holder.CompleteCheckBox.Checked == true)
                    State.ListTasks[position].Completed = true;
                else
                    State.ListTasks[position].Completed = false;

                ChangeTextStyle(holder, position);

                State.ListTasks.SortList();
                (_context as MainActivity).UpdateFragment();
            };
        }

        private void InitPriorityView (ViewHolder holder, int position)
        {
            string text = "";
            Color color = new Color();

            if (State.ListTasks[position] is SingleTask)
            {
                int priorityTask = (State.ListTasks[position] as SingleTask).Priority;
                text = priorityTask.ToString();
                color = new Color(ContextCompat.GetColor(_context, Helper.PriorityToColorId[priorityTask]));
            }
            if (State.ListTasks[position] is RoutineTask)
            {
                text = "->\n<-";
                color = Color.Green;
            }

            holder.PriorityView.Text = text;
            holder.PriorityView.SetTextColor(color);
            color.A = 25;
            holder.PriorityView.SetBackgroundColor(color);
        }
    }
}
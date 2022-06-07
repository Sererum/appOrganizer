using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appOrganizer.Organizer.Tasks
{
    class ListTasks
    {
        private List<Task> _tasks;
        public ListTasks ()
        {
            _tasks = new List<Task>();
        }

        public void AddTask(string label, string textTask)
        {
            _tasks.Add(new Task(label, textTask));
        }

        public void DeleteTask(int index)
        {
            _tasks.RemoveAt(index);
        }
    }
}
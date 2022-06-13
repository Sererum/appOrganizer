using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using appOrganizer.Organizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appOrganizer.Organizer.Tasks
{
    public class ListTasks
    {
        private List<Task> _tasks;

        public ListTasks (string listTask = "")
        {
            _tasks = new List<Task>();

            if (listTask == "")
                return;

            string[] arrayTasks = listTask.Split('╬');

            foreach (string task in arrayTasks)
                _tasks.Add(new Task(task));

            SortList();
        }

        public override string ToString ()
        {
            string listTask = "";

            foreach (Task task in _tasks)
                listTask += task.ToString() + "╬";

            return listTask[..^1];
        }
        
        public Task this[int position]
        {
            get { return _tasks[position]; }
        }

        public int Count
        {
            get { return _tasks.Count; }
        }

        public void AddTask(string label, string textTask)
        {
            _tasks.Add(new Task(label, textTask));
            SortList();
        }

        public void DeleteTask(int position)
        {
            _tasks.RemoveAt(position);
        }

        public void CompleteTask(bool complete, int position)
        {
            _tasks[position].Completed = complete;
            SortList();
        }

        public void SortList ()
        {
            _tasks.Sort((taskOne, taskTwo) => taskOne.CompareTo(taskTwo));
        }
    }
}
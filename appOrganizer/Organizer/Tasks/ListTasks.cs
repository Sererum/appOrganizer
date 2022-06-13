using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
        public ListTasks ()
        {
            _tasks = new List<Task>();
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
        }

        public void DeleteTask(int index)
        {
            _tasks.RemoveAt(index);
        }

        public void ReplaceTask (int indexOldTask, Task newTask)
        {
            _tasks[indexOldTask] = newTask;
        }

        public override string ToString ()
        {
            string listTask = "";

            foreach (Task task in _tasks)
                listTask += task.ToString() + "╬";

            return listTask[..^1];
        }

        public ListTasks(string listTask)
        {
            _tasks = new List<Task>();

            if (listTask == "")
                return;

            string[] arrayTasks = listTask.Split('╬');

            foreach (string task in arrayTasks)
                _tasks.Add(new Task(task));
        }
    }
}
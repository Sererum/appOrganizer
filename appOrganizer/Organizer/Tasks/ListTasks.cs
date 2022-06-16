using Android.Util;
using appOrganizer.Organizer.Tasks.KindTasks;
using System;
using System.Collections.Generic;

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

            foreach (string sTask in arrayTasks)
            {
                switch ((Task.KindTasks) Int32.Parse(sTask[0].ToString()))
                {
                    case Task.KindTasks.Single:
                    {
                        _tasks.Add(new SingleTask(sTask));
                        break;
                    }
                    case Task.KindTasks.Routine:
                    {
                        _tasks.Add(new RoutineTask(sTask));
                        break;
                    }
                    case Task.KindTasks.Project:
                    {
                        _tasks.Add(new ProjectTask(sTask));
                        break;
                    }
                }
            }

            SortList();
        }

        public override string ToString ()
        {
            string listTask = "";

            foreach (Task task in _tasks)
                listTask += task.ToString() + "╬";

            if (listTask.Length == 0)
                return "";
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

        public void AddTask(Task task)
        {
            if (_tasks.Contains(task))
                return;

            _tasks.Add(task);
            SortList();
        }

        public void DeleteTask(int position)
        {
            _tasks.RemoveAt(position);
        }

        public void DeleteTask(Task task)
        {
            _tasks.Remove(task);
        }

        public void CompleteTask(bool complete, int position)
        {
            _tasks[position].Completed = complete;
            SortList();
        }

        public void SortList ()
        {
            _tasks.Sort((taskOne, taskTwo) => Task.CompareTo(taskOne, taskTwo));
        }

        public ListTasks CutUncompleteTasks ()
        {
            ListTasks listTasks = new ListTasks();
            List<Task> deleteTasks = new List<Task>();

            foreach (Task task in _tasks)
            {
                if (task.Completed == false)
                {
                    listTasks.AddTask(task);
                    deleteTasks.Add(task);
                }
            }
            foreach (Task task in deleteTasks)
                _tasks.Remove(task);

            return listTasks;
        }

        public static ListTasks operator + (ListTasks listOne, ListTasks listTwo)
        {
            ListTasks finalList = new ListTasks();

            for (int i = 0; i < listOne.Count; i++)
            {
                if (listOne[i] is RoutineTask == false)
                    finalList.AddTask(listOne[i]);
            }
                

            for (int i = 0; i < listTwo.Count; i++)
            {
                if (listTwo[i] is RoutineTask == false)
                    finalList.AddTask(listTwo[i]);
            }

            return finalList;
        }
    }
}
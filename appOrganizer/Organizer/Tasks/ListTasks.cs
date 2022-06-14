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
                _tasks.Add(new Task(sTask));

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
            _tasks.Add(task);
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
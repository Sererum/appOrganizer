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

namespace appOrganizer.Organizer.Tasks.KindTasks
{
    class ProjectTask : Task
    {
        public ProjectTask (string title, string textTask) : base(title, textTask, Task.KindTasks.Project)
        {
        }

        public ProjectTask (string task) : base(task)
        {
        }

        public override string ToString ()
        {
            return base.ToString();
        }
    }
}
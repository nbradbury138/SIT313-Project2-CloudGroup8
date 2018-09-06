using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Project2.Helpers;
using Project2.Model;
using Project2.Data;
using Xamarin.Forms;

namespace Project2.ViewModel
{
    public class BaseTaskViewModel : INotifyPropertyChanged
    {
        //declare class variables
        public TaskData task;
        public INavigation nav;
        public TaskDataRepository taskRepo;
        List<TaskData> taskDataList;

        //property for task name
        public string TaskName
        {
            get { return task.TaskName; }
            set
            {
                task.TaskName = value;
                NotifyPropertyChanged("TaskName");
            }
        }

        //property for description
        public string Description
        {
            get { return task.Description; }
            set
            {
                task.Description = value;
                NotifyPropertyChanged("Description");
            }
        }

        //property for due date
        public DateTime DueDate
        {
            get { return task.DueDate; }
            set
            {
                task.DueDate = value;
                NotifyPropertyChanged("DueDate");
            }
        }

        //property for priority
        public string Priority
        {
            get { return task.Priority; }
            set
            {
                task.Priority = value;
                NotifyPropertyChanged("Priority");
            }
        }

        //property for status
        public string Status
        {
            get { return task.Status; }
            set
            {
                task.Status = value;
                NotifyPropertyChanged("Status");
            }
        }

        //property for user
        public string User
        {
            get { return task.User; }
            set
            {
                task.User = value;
                NotifyPropertyChanged("User");
            }
        }

        //property for task list
        public List<TaskData> TaskDataList
        {
            get { return taskDataList; }
            set
            {
                taskDataList = value;
                NotifyPropertyChanged("TaskDataList");
            }
        }

        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

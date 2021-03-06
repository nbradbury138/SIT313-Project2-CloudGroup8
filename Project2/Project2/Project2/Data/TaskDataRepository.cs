﻿using Project2.Helpers;
using Project2.Model;
using System.Collections.ObjectModel;

namespace Project2.Data
{
    public class TaskDataRepository
    {
        DBHelper dbhelp;
        public TaskDataRepository()
        {
            dbhelp = new DBHelper();
        }

        #region Task Methods

        public void DeleteTask(int taskId)
        {
            dbhelp.DeleteTask(taskId);
        }

        public void DeleteAllTasks()
        {
            dbhelp.DeleteAllTasks();
        }

        public ObservableCollection<TaskData> GetAllTasks()
        {
            return dbhelp.GetAllTasks();
        }

        public ObservableCollection<TaskData> GetAllTasksForUser(string user)
        {
            return dbhelp.GetAllTasksForUser(user);
        }

        public TaskData GetTask(int taskId)
        {
            return dbhelp.GetTaskData(taskId);
        }

        public void InsertTask(TaskData task)
        {
            dbhelp.InsertTask(task);
        }

        public void UpdateTask(TaskData task)
        {
            dbhelp.UpdateTask(task);
        }
        #endregion Task Methods
    }
}

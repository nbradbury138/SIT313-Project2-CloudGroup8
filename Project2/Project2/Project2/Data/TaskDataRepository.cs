
using System.Collections.Generic;
using Project2.Helpers;
using Project2.Model;
using Project2.Interfaces;
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

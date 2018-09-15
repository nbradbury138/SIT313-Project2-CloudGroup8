using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using Project2.Model;
using Project2.Interfaces;
using System.Collections.ObjectModel;

namespace Project2.Helpers
{
    class DBHelper
    {
        //set variables for connection and filename.
        static SQLiteConnection connection;
        public const string fileName = "taskdatabase.db";

        public DBHelper()
        {
            //call the get conneciton method
            connection = DependencyService.Get<SQLInterface>().GetConnection();
            
            //create the Task Table if needed and populate
            string statement = "SELECT * FROM sqlite_master where type = 'table' and tbl_name = 'TaskData'";
            var command = connection.CreateCommand(statement);
            if(command.ExecuteScalar<string>() == null)
            {
                connection.CreateTable<TaskData>();
                //populate with test data
                CreateTaskData();
            }
        }

        #region Task Data Methods
        //get all task data info
        public ObservableCollection<TaskData> GetAllTasks()
        {
            List<TaskData> list = (from data in connection.Table<TaskData>()
                                   select data).ToList();

            ObservableCollection<TaskData> taskList = new ObservableCollection<TaskData>(list);

            return taskList;
        }

        //Get Specific Task data  
        public TaskData GetTaskData(int id)
        {
            return connection.Table<TaskData>().FirstOrDefault(t => t.Id == id);
        }

        // Delete all Task Data  
        public void DeleteAllTasks()
        {
            connection.DeleteAll<TaskData>();
        }

        // Delete Specific Task  
        public void DeleteTask(int id)
        {
            connection.Delete<TaskData>(id);
        }

        // Insert new Task  
        public void InsertTask(TaskData task)
        {
            connection.Insert(task);
        }

        // Update Task Data  
        public void UpdateTask(TaskData task)
        {
            connection.Update(task);
        }

        #endregion Task Data Methods

       

        public void CreateTaskData()
        {
            if(connection.Table<TaskData>().Count() == 0)
            {
                TaskData newTask1 = new TaskData("Finish Work","I need to finish my work","High","nathan@email.com","To Do",Convert.ToDateTime("20/SEP/18"),DateTime.Now);
                TaskData newTask2 = new TaskData("Submit Report", "The report on Visual Studio", "Medium", "nathan@email.com", "In Progress", Convert.ToDateTime("21/OCT/18"),DateTime.Now);
                TaskData newTask3 = new TaskData("File papers", "Have to file all those papers", "Low", "glenn@email.com", "Completed", Convert.ToDateTime("15/AUG/18"),DateTime.Now);
                TaskData newTask4 = new TaskData("Develop application", "The Task management application needs In Progress", "High", "glenn@email.com", "In Progress", Convert.ToDateTime("26/SEP/18"),DateTime.Now);

                connection.Insert(newTask1);
                connection.Insert(newTask2);
                connection.Insert(newTask3);
                connection.Insert(newTask4);

            }
        }   
    }
}

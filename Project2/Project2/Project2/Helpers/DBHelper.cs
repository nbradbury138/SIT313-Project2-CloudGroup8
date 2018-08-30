using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using Project2.Model;
using Project2.Interfaces;

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

            //create the User Table if needed and populate
            statement = "SELECT * FROM sqlite_master where type = 'table' and tbl_name = 'UserData'";
            command = connection.CreateCommand(statement);
            if (command.ExecuteScalar<string>() == null)
            {
                connection.CreateTable<UserData>();
                //populate with test data
                CreateUserData();
            }

            //create the Priority Table if needed
            statement = "SELECT * FROM sqlite_master where type = 'table' and tbl_name = 'LUPriority'";
            command = connection.CreateCommand(statement);
            if (command.ExecuteScalar<string>() == null)
            {
                connection.CreateTable<LUPriority>();
                CreatePriorityData();
            }

            //create the Status Table if needed
            statement = "SELECT * FROM sqlite_master where type = 'table' and tbl_name = 'LUPriority'";
            command = connection.CreateCommand(statement);
            if (command.ExecuteScalar<string>() == null)
            {
                connection.CreateTable<LUStatus>();
                CreateStatusData();
            }   
        }

        #region Task Data Methods
        //get all task data info
        public List<TaskData> GetAllTasks()
        {
            return (from data in connection.Table<TaskData>()
                    select data).ToList();
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

        #region User Data Methods
        //get all user data info
        public List<UserData> GetAllUserData()
        {
            return (from data in connection.Table<UserData>()
                    select data).ToList();
        }

        //Get Specific User data  
        public UserData GetUserData(string userName)
        {
            return connection.Table<UserData>().FirstOrDefault(t => t.UserName == userName);
        }

        // Delete all User Data  
        public void DeleteAllUserData()
        {
            connection.DeleteAll<UserData>();
        }

        // Delete Specific User  
        public void DeleteUser(int id)
        {
            connection.Delete<UserData>(id);
        }

        // Insert new User  
        public void InsertUser(UserData user)
        {
            connection.Insert(user);
        }

        // Update User Data  
        public void UpdateUser(UserData user)
        {
            connection.Update(user);
        }

        #endregion User Data Methods

        #region Priority Data Methods
        //get all Priority data info
        public List<LUPriority> GetAllPriorityData()
        {
            return (from data in connection.Table<LUPriority>()
                    select data).ToList();
        }

        //Get Specific Priority data  
        public LUPriority GetPriorityData(string code)
        {
            return connection.Table<LUPriority>().FirstOrDefault(t => t.PriorityCode == code);
        }

        // Delete all Priority Data  
        public void DeleteAllPriorityData()
        {
            connection.DeleteAll<LUPriority>();
        }

        // Delete Specific Priority  
        public void DeletePriority(string code)
        {
            connection.Delete<LUPriority>(code);
        }

        // Insert new Priority  
        public void InsertPriority(LUPriority priority)
        {
            connection.Insert(priority);
        }

        // Update Priority Data  
        public void UpdatePriority(LUPriority priority)
        {
            connection.Update(priority);
        }

        #endregion Priority Data Methods

        #region Status Data Methods
        //get all Status data info
        public List<LUStatus> GetAllStatusData()
        {
            return (from data in connection.Table<LUStatus>()
                    select data).ToList();
        }

        //Get Specific Status data  
        public LUStatus GetStatus(string code)
        {
            return connection.Table<LUStatus>().FirstOrDefault(t => t.StatusCode == code);
        }

        // Delete all Status Data  
        public void DeleteAllStatus()
        {
            connection.DeleteAll<LUStatus>();
        }

        // Delete Specific Task  
        public void DeleteStatus(string code)
        {
            connection.Delete<LUStatus>(code);
        }

        // Insert new Status  
        public void InsertStatus(LUStatus status)
        {
            connection.Insert(status);
        }

        // Update Status Data  
        public void UpdateStatus(LUStatus status)
        {
            connection.Update(status);
        }

        #endregion Status Data Methods

        public void CreateTaskData()
        {
            if(connection.Table<TaskData>().Count() == 0)
            {
                TaskData newTask1 = new TaskData("Finish Work","I need to finish my work","high","nathan","current",Convert.ToDateTime("20/SEP/18"));
                TaskData newTask2 = new TaskData("Submit Report", "The report on Visual Studio", "medium", "nathan", "current", Convert.ToDateTime("21/OCT/18"));
                TaskData newTask3 = new TaskData("File papers", "Have to file all those papers", "low", "glenn", "complete", Convert.ToDateTime("15/AUG/18"));
                TaskData newTask4 = new TaskData("Develop application", "The Task management application needs completing", "high", "glenn", "current", Convert.ToDateTime("26/SEP/18"));

                connection.Insert(newTask1);
                connection.Insert(newTask2);
                connection.Insert(newTask3);
                connection.Insert(newTask4);

            }
        }

        public void CreateUserData()
        {
            if (connection.Table<TaskData>().Count() == 0)
            {
                UserData newUser1 = new UserData("nathan","nathan");
                UserData newUser2 = new UserData("glenn", "glenn");
                UserData newUser3 = new UserData("john", "john");

                connection.Insert(newUser1);
                connection.Insert(newUser2);
                connection.Insert(newUser3);
            }
        }

        public void CreatePriorityData()
        {
            if (connection.Table<TaskData>().Count() == 0)
            {
                LUPriority newPriority1 = new LUPriority("h","high");
                LUPriority newPriority2 = new LUPriority("m", "medium");
                LUPriority newPriority3 = new LUPriority("l", "low");

                connection.Insert(newPriority1);
                connection.Insert(newPriority2);
                connection.Insert(newPriority3);

            }
        }

        public void CreateStatusData()
        {
            if (connection.Table<TaskData>().Count() == 0)
            {
                LUStatus newStatus1 = new LUStatus("cu", "current");
                LUPriority newStatus2 = new LUPriority("co", "complete");

                connection.Insert(newStatus1);
                connection.Insert(newStatus2);

            }
        }
    }
}

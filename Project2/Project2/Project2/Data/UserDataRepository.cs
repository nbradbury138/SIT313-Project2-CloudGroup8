
using System.Collections.Generic;
using Project2.Helpers;
using Project2.Model;
using Project2.Interfaces;

namespace Project2.Data
{
    public class UserDataRepository
    {
        DBHelper dbhelp;
        public UserDataRepository()
        {
            dbhelp = new DBHelper();
        }

        public void DeleteUser(int userid)
        {
            dbhelp.DeleteUser(userid);
        }

        public void DeleteAllUsers()
        {
            dbhelp.DeleteAllUserData();
        }

        public List<UserData> GetAllUserData()
        {
            return dbhelp.GetAllUserData();
        }

        public UserData GetUserData(string username)
        {
            return dbhelp.GetUserData(username);
        }

        public void InsertUser(UserData user)
        {
            dbhelp.InsertUser(user);
        }

        public void UpdateTask(TaskData task)
        {
            dbhelp.UpdateTask(task);
        }       
    }
}

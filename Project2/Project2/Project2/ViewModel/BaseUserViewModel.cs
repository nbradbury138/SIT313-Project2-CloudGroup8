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
    public class BaseUserViewModel : INotifyPropertyChanged
    {
        //declare class variables
        public UserData user;
        public INavigation nav;
        public UserDataRepository userRepo;
        List<UserData> userListData;

        //property for task name
        public string Username
        {
            get { return user.UserName; }
            set
            {
                user.UserName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        //property for description
        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        //property for task list
        public List<UserData> UserDataList
        {
            get { return userListData; }
            set
            {
                userListData = value;
                NotifyPropertyChanged("UserDataList");
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

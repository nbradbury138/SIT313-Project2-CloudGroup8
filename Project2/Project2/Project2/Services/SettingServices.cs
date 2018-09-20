using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace Project2.Services
{
    public static class SettingServices
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }

            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }
        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static DateTime AccessTokenExpirationDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessTokenExpirationDate", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessTokenExpirationDate", value);
            }
        }

        public static DateTime LastSynchronisationTime
        {
            get
            {
                return AppSettings.GetValueOrDefault("LastSynchronisationTime", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("LastSynchronisationTime", DateTime.UtcNow);
            }
        }
        public static string Connected
        {
            get
            {
                return AppSettings.GetValueOrDefault("Connected", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Connected", value);
            }
        }
    }
}
using Project2.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project2.Services;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Project2
{
	public partial class App : Application
	{
        public bool CurrentlyConnected;

        public App()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(SettingServices.AccessToken))
            {
                if (SettingServices.AccessTokenExpirationDate > DateTime.UtcNow.AddHours(1))
                    MainPage = new NavigationPage(new HomePage());
            }
            else
                MainPage = new NavigationPage(new Login());
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            base.OnStart();
            CrossConnectivity.Current.ConnectivityChanged += SynchroniseChanges;
		}

        private async void SynchroniseChanges(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.IsConnected)
            {
                if (SettingServices.AccessToken != null && SettingServices.AccessTokenExpirationDate.AddHours(2) > DateTime.Now)
                {
                    await DataServices.Synchronise();
                    SettingServices.LastSynchronisationTime = DateTime.Now;
                }
            }
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

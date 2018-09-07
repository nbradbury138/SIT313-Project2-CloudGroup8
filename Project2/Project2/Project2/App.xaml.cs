using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project2.View;
using Project2.Data;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Project2
{
	public partial class App : Application
	{
		public App ()
		{
		    InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1()
		{
			InitializeComponent();

            BindingContext = new TaskListViewModel(Navigation);
		}
	}
}
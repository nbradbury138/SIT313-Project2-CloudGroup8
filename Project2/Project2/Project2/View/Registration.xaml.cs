using Xamarin.Forms;
using Project2.ViewModel;

namespace Project2.View
{
	public partial class Registration : ContentPage
	{
		public Registration ()
		{
			InitializeComponent();
            BindingContext = new RegisterViewModel(Navigation);
        }
	}
}
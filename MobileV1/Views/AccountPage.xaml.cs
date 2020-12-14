using MobileV1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        
        public AccountPage()
        {
            InitializeComponent();
        }

        protected  override void OnAppearing()
        {
            BindingContext = new AccountPageViewModel();
            
            base.OnAppearing();
        }
    }
}
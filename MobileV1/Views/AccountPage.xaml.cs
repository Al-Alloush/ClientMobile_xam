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
            BindingContext = new AccountPageViewModel();
            InitializeComponent();
        }
    }
}
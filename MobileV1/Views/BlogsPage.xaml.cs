using MobileV1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogsPage : ContentPage
    {

        public BlogsPage()
        {
            BindingContext = new BlogsPageViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
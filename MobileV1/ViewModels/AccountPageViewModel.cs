using MobileV1.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace MobileV1.ViewModels
{
    class AccountPageViewModel
    {
        public Command LoginBtnClicked { get; }
        public AccountPageViewModel()
        {
            LoginBtnClicked = new Command(LoginFun);
        }

        private async void LoginFun(object obj)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}

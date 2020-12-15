using MobileV1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MobileV1.ViewModels
{
    class AccountPageViewModel : BaseViewModel
    {
        private string _username = "USER_NAME";

        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value);  }
        }
        public Command LoginBtnClicked { get; }
        public Command SingoutBtnClicked { get; }

        private bool _LoginBannerLayout = true;
        public bool LoginBannerLayout
        {
            get { return _LoginBannerLayout; }
            set { SetProperty(ref _LoginBannerLayout, value); }
        }
        private bool _SuccessLoginLayouts = false;
        public bool SuccessLoginLayouts
        {
            get { return _SuccessLoginLayouts; }
            set { SetProperty(ref _SuccessLoginLayouts, value); }
        }

        public AccountPageViewModel()
        {
            SingoutBtnClicked = new Command(Singout);
            LoginBtnClicked = new Command(LoginFun);
            if (Application.Current.Properties.ContainsKey("UserName"))
                UserName = Application.Current.Properties["UserName"].ToString();

            LoginBannerLayout  = false;
            SuccessLoginLayouts  = true;
            // change the layouts visibilty 
            LayoutsVisible();

        }

        private void LayoutsVisible()
        {
            bool loginSuccess = false;
            if (Application.Current.Properties.ContainsKey("Token"))
                if (Application.Current.Properties["Token"] != null)
                    loginSuccess = true;

            if (loginSuccess)
            {
                LoginBannerLayout  = false;
                SuccessLoginLayouts  = true;
            }
            else
            {
                LoginBannerLayout  = true;
                SuccessLoginLayouts  = false;
            }
        }

        private void Singout(object obj)
        {
            Application.Current.Properties["Token"] = null;
            Application.Current.Properties["UsetrName"] = null;
            LayoutsVisible();
        }

        private async void LoginFun(object obj)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}

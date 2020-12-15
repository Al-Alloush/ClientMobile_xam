
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileV1.ViewModels
{
    class RegisterPageViewModel
    {
        public Command CancelCommand { get; }
        public Command RegisterBtnClicked { get; }

        public RegisterPageViewModel()
        {
            CancelCommand = new Command(OnCancel);
            RegisterBtnClicked = new Command(RegisterFun);
        }

        private void RegisterFun(object obj)
        {
            throw new NotImplementedException();
        }

        private async void OnCancel(object obj)
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

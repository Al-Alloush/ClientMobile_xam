﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MobileV1.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {

        private string _usernameOrEmail;
        public string UsernameOrEmail
        {
            get { return _usernameOrEmail; }
            set { SetProperty(ref _usernameOrEmail, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public Command CancelCommand { get; }
        public Command LoginBtnClicked { get; }


        public LoginPageViewModel()
        {
            // ValidateLogin is to set the login as disable 
            LoginBtnClicked = new Command(Login, ValidateLogin);
            // to active Login button after write in two fields(UsernameOrEmail and Password)
            this.PropertyChanged += (_, __) => LoginBtnClicked.ChangeCanExecute();

            CancelCommand = new Command(OnCancel);

        }

        private bool ValidateLogin(object agr)
        {
            return !String.IsNullOrWhiteSpace(_usernameOrEmail)
                && !String.IsNullOrWhiteSpace(_password);
        }

        private void Login(object obj)
        {
            Debug.WriteLine($"Loing ....... {UsernameOrEmail}/{Password} ");
        }

        private async void OnCancel(object obj)
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }


        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
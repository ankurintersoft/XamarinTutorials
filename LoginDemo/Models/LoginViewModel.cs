using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LoginDemo.Models
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;

            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                //This statement will notify the xaml file that changes are made and needs to be reflected
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {

                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else
            {
                //we can also push from here by following code instead of pushing from SignInHandlerMV
                //App.Current.MainPage.Navigation.PushAsync(new LoginPage());

            }
        }
    }
}

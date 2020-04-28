using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using LoginDemo.Interface;
using LoginDemo.Services;
using Xamarin.Forms;

namespace LoginDemo.Models
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IApi _api;
        public LoginViewModel(string email, string password, IApi api)
        {
            _api = api;
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
                //check if it is not null and validate the email
                if (Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    //_ = await _api.Login(new LoginRequest("test2", "password", "vmware100!"));
                    var response = await CallAPI.UserLogin("test2", "password", "vmware100!");
                    if (response.isError)
                    {
                        Console.WriteLine("error in login");
                    }
                    else
                    {
                        Console.WriteLine("got success in login");
                    }
                }
                else
                {
                    Console.WriteLine("failure");
                    await App.Current.MainPage.DisplayAlert("Alert", "Please enter a valid email", "OK");
                }

                //we can also push from here by following code instead of pushing from SignInHandlerMV
                //App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
        }
    }
}

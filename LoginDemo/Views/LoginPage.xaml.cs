using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginDemo
{
    public partial class LoginPage : ContentPage
    {
        //In this case, View Model is same class as View class
        //using this operator to let the compiler know about the ViewModel class for this View class
        public string UserText { get; set; }
        public string Passwordtext { get; set; }

        public LoginPage()
        {
            this.UserText = "ankur.intersoft@gmail.com";
            this.Passwordtext = "**************";
            InitializeComponent();
            BindingContext = this;
        }

        async void SignInHandler(object sender, EventArgs args)
        {
            //get email from userName field
            string email = userNameEntry.Text;

            //check if it is not null and validate the email
            if (email != null && Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                activityIndicator.IsVisible = true;
                loginActivityIndicator.IsRunning = true;
                Console.WriteLine("success show indicator");
            }
            else
            {
                Console.WriteLine("failure");
                await DisplayAlert("Alert", "Please enter a valid email", "OK");
            }
        }

        async void ResetHandler(object sender, EventArgs args)
        {
            //just to show popup when reset button is clicked
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }

        void Username_Entry_Completed(object sender, EventArgs e)
        {
            //username filed gets in this func after it has completed entering text
            var text = ((Entry)sender).Text;
            Console.WriteLine("User entered '" + text + "' in username field");
        }

        void Password_Entry_Completed(object sender, EventArgs e)
        {
            //password filed gets in this func after it has completed entering text
            var text = ((Entry)sender).Text;
            Console.WriteLine("User entered '" + text + "' in password field");
        }
    }
}

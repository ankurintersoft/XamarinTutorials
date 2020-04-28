using System;
using System.Collections.Generic;
using LoginDemo.Models;
using LoginDemo.Services;
using Xamarin.Forms;

namespace LoginDemo.Views
{
    public partial class LoginPageWithViewModel : ContentPage
    {
        private LoginViewModel loginViewModel;

        public LoginPageWithViewModel()
        {
            loginViewModel = new LoginViewModel("ankur.int@mail.com", "123456789", ApiService.Instance);

            InitializeComponent();
            BindingContext = loginViewModel;
        }

        //Page LifeCycle
        protected override void OnAppearing()
        {
            base.OnAppearing();
            System.Diagnostics.Debug.WriteLine("*****Here*****");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            System.Diagnostics.Debug.WriteLine("*****Gone*****");
        }

        void SignInHandlerMV(object sender, EventArgs args)
        {
            //await this.Navigation.PushAsync(new LoginDemo.LoginPage());
        }

        void ResetHandlerMV(object sender, EventArgs args)
        {
            //On reset button click, login model values will be changed and LoginModel's setter block will be instanciated
            //To reflect the changed values on the screen, eventNotifier is used in setter block only in password field just to check the significance of eventnotifier.
            loginViewModel.Email = "ankbank@mail.com";
            loginViewModel.Password = "force set";

        }

        void Username_Entry_CompletedMV(object sender, EventArgs e)
        {
            //username filed gets in this func after it has completed entering text
            var text = ((Entry)sender).Text;
            Console.WriteLine("User entered '" + text + "' in username field");
        }

        void Password_Entry_CompletedMV(object sender, EventArgs e)
        {
            //password filed gets in this func after it has completed entering text
            var text = ((Entry)sender).Text;
            Console.WriteLine("User entered '" + text + "' in password field");
        }
    }
}

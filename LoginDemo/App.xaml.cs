using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.LoginPageWithViewModel());
        }

        protected override void OnStart()
        {
            //when app starts
        }

        protected override void OnSleep()
        {
            //when app gets in background
        }

        protected override void OnResume()
        {
            //when app gets in foreground state from background state
        }
    }
}

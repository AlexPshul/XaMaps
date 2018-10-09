using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XaMaps.ViewModels;
using XaMaps.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XaMaps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage { BindingContext = new MainViewModel() };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

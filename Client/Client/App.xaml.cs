using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Client.Views;
using Client.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Client
{
    public partial class App : Application
    {
        public static string APIBackendUrl = "http://192.168.0.10:5000";
        public static bool UseMockDataStore = false;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<APIDataStore>();

            MainPage = new Home();

            //MainPage = new NavigationPage(new MainCsPage());
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

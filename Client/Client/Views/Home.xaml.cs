using Client.Helpers;
using Client.Models;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class Home : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public Home()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Adding menu items to menuList and you can define title ,page and icon
            menuList.Add(new MasterPageItem() { Title = "Home", Icon = "home.png", TargetType = typeof(ItemsPage) });
            menuList.Add(new MasterPageItem() { Title = "Map", Icon = "navigation.png", TargetType = typeof(Map) });
            menuList.Add(new MasterPageItem() { Title = "SearchBar", Icon = "search.png", TargetType = typeof(SearchBar) });
            menuList.Add(new MasterPageItem() { Title = "Login", Icon = "login.png", TargetType = typeof(Login) });
            menuList.Add(new MasterPageItem() { Title = "Register", Icon = "register.png", TargetType = typeof(Register) });
            menuList.Add(new MasterPageItem() { Title = "Profile", Icon = "user.png", TargetType = typeof(Profile) });

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                if (Settings.AccessTokenExpirationDate < DateTime.UtcNow.AddHours(1))
                {
                    var loginViewModel = new LoginViewModel();
                    loginViewModel.LoginCommand.Execute(null);
                }
            }
            else if (!string.IsNullOrEmpty(Settings.Username)
                  && !string.IsNullOrEmpty(Settings.Password))
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Login)));
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Register)));
            }

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Login)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NuevoYazilim.Languages;
using NuevoYazilim.Models;
using NuevoYazilim.Services;
using Xamarin.Forms;

namespace NuevoYazilim.Views
{
    public partial class LoginPage : ContentPage
    {
        Entry entUsername;
        Entry entPassword;

        public LoginPage()
        {
            InitializeComponent();

            LoadTemplate();
        }

        public void LoadTemplate()
        {
            StackLayout mainStackLayout = new StackLayout();
            mainStackLayout.Orientation = StackOrientation.Vertical;
            mainStackLayout.Padding = new Thickness(0, 30, 0, 0);
            mainStackLayout.Spacing = 40;

            Label label = new Label();
            label.Text = AppResource.Welcome;
            label.TextColor = Color.CadetBlue;
            label.FontSize = 30;
            label.FontAttributes = FontAttributes.Bold;
            label.HorizontalOptions = LayoutOptions.Center;

            StackLayout stackLayoutStc = new StackLayout();
            stackLayoutStc.Orientation = StackOrientation.Vertical;
            stackLayoutStc.Spacing = 10;
            stackLayoutStc.VerticalOptions = LayoutOptions.StartAndExpand;

            entUsername = new Entry();
            entUsername.Text = "";
            entUsername.Placeholder = AppResource.Email;
            entUsername.PlaceholderColor = Color.Gray;
            entUsername.HeightRequest = 40;
            entUsername.Keyboard = Keyboard.Email;
            entUsername.TextColor = Color.Black;
            entUsername.VerticalOptions = LayoutOptions.Center;

            entPassword = new Entry();
            entPassword.Text = "";
            entPassword.Placeholder = AppResource.Password;
            entPassword.PlaceholderColor = Color.Gray;
            entPassword.HeightRequest = 40;
            entPassword.Keyboard = Keyboard.Default;
            entPassword.TextColor = Color.Black;
            entPassword.IsPassword = true;
            entPassword.VerticalOptions = LayoutOptions.Center;

            Button button = new Button();
            button.Text = AppResource.Login;
            button.TextColor = Color.White;
            button.FontAttributes = FontAttributes.Bold;
            button.FontSize = 15;
            button.HorizontalOptions = LayoutOptions.Fill;
            button.BackgroundColor = Color.CadetBlue;
            button.Clicked += Button_Clicked;

            Label footerLabel = new Label();
            footerLabel.Text = AppResource.Version;
            footerLabel.TextColor = Color.Gray;
            footerLabel.Opacity = 0.7;
            footerLabel.FontSize = 11;
            footerLabel.HorizontalOptions = LayoutOptions.Center;
            footerLabel.VerticalOptions = LayoutOptions.End;

            mainStackLayout.Children.Add(label);
            mainStackLayout.Children.Add(stackLayoutStc);
            stackLayoutStc.Children.Add(entUsername);
            stackLayoutStc.Children.Add(entPassword);
            mainStackLayout.Children.Add(button);
            mainStackLayout.Children.Add(footerLabel);

            Content = mainStackLayout;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var entity = new LoginModel()
            {
                email = entUsername.Text,
                password = entPassword.Text
            };

            if (string.IsNullOrEmpty(entity.email) || string.IsNullOrEmpty(entity.password))
            {
               await DisplayAlert(AppResource.Warning, AppResource.Empty, AppResource.Ok);
            }
            else
            {
                LoginService login = new LoginService();
                var result=await login.Login(entity);

                if (result==1)
                {
                    await this.Navigation.PushModalAsync(new DetailList());
                }
                else if (result==0)
                {
                    await DisplayAlert(AppResource.Warning, AppResource.WarningEx, AppResource.Ok);
                }
                else
                {
                    await DisplayAlert(AppResource.Error, AppResource.ErrorEx, AppResource.Ok);
                }
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NuevoYazilim.Languages;
using Xamarin.Forms;

namespace NuevoYazilim.Views
{
    public class Language: ContentPage
    {
        public Language()
        {
            StackLayout mainStackLayout = new StackLayout();
            mainStackLayout.Orientation = StackOrientation.Vertical;
            mainStackLayout.Padding = new Thickness(0, 30, 0, 0);
            mainStackLayout.Spacing = 40;

            Label label = new Label();
            label.Text = "Welcome";
            label.TextColor = Color.CadetBlue;
            label.FontSize = 30;
            label.FontAttributes = FontAttributes.Bold;
            label.HorizontalOptions = LayoutOptions.Center;

            var langItems = new List<string>();
            langItems.Add("Türkçe");
            langItems.Add("English");

            Picker picker = new Picker();
            picker.ItemsSource = langItems;
            picker.Title = "Select Language";
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;


            mainStackLayout.Children.Add(label);
            mainStackLayout.Children.Add(picker);
            

            Content = mainStackLayout;

        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string lang = picker.SelectedIndex == 0 ? "tr" : "en";
            CultureInfo language = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = language;
            AppResource.Culture = language;

            await this.Navigation.PushModalAsync(new LoginPage());
        }
    }
}

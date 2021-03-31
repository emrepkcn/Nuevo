using System;
using NuevoYazilim.Languages;
using NuevoYazilim.Services;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace NuevoYazilim.Views
{
    public partial class ColorPopup:PopupPage
    {
        int id;
        public ColorPopup(int _id)
        {
            id = _id;
            ShowPopup();
        }

        public async void ShowPopup()
        {
            ColorService colorService = new ColorService();
            var data = await colorService.ColorDetail(id);
            var color = data.data;

            Label lblTitle = new Label()
            {
                Text = AppResource.ColorDetail,
                Margin = new Thickness(20),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
            };

            StackLayout stkTitle = new StackLayout
            {
                Children =
                {
                    lblTitle
                }
            };

            Label lblId = new Label()
            {
                Text = color.id.ToString(),
                FontSize = 20,
                TextColor = Color.WhiteSmoke,
                WidthRequest = 300,
                MinimumWidthRequest = 300,
                HeightRequest = 40,
                MinimumHeightRequest = 40,
                HorizontalTextAlignment = TextAlignment.Center
            };

            StackLayout stkId = new StackLayout
            {
                Children =
                {
                    lblId
                }
            };

            Label lblName = new Label()
            {
                Text = color.name,
                FontSize = 20,
                TextColor = Color.WhiteSmoke,
                WidthRequest = 300,
                MinimumWidthRequest = 300,
                HeightRequest = 40,
                MinimumHeightRequest = 40,
                TextTransform = TextTransform.Uppercase,
                HorizontalTextAlignment = TextAlignment.Center
            };

            StackLayout stkName = new StackLayout
            {
                Children =
                {
                    lblName
                }
            };


            Label lblYear = new Label()
            {
                Text = color.year.ToString(),
                FontSize = 20,
                TextColor = Color.WhiteSmoke,
                WidthRequest = 300,
                MinimumWidthRequest = 300,
                HeightRequest = 40,
                MinimumHeightRequest = 40,
                HorizontalTextAlignment = TextAlignment.Center
            };

            StackLayout stkYear = new StackLayout
            {
                Children =
                {
                    lblYear
                }
            };

            StackLayout body = new StackLayout
            {
                BackgroundColor = Color.FromHex(color.color),
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(10),
                Children =
                {
                    stkTitle,
                    stkId,
                    stkName,
                    stkYear
                }
            };

            Content = body;
        }
    }
}

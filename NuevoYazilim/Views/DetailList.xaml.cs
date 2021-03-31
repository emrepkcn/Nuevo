using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NuevoYazilim.Languages;
using NuevoYazilim.Models;
using NuevoYazilim.Services;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace NuevoYazilim.Views
{
    public partial class DetailList : ContentPage
    {
        ListView listView;

        public DetailList()
        {
            LoadData();
            LoadTemplate();
        }

        public async void LoadData()
        {
            var entity = new ColorModel();

            ColorService colorService = new ColorService();
            var result = await colorService.ColorList(entity);

            listView.ItemsSource = result.data;

        }

        private void LoadTemplate()
        {

            Label header = new Label
            {
                Text = AppResource.ColorList,
                Margin = new Thickness(20),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
            };



            listView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    Label name_Label = new Label()
                    {
                        FontSize = 16,
                        TextColor = Color.WhiteSmoke,
                        HorizontalOptions = LayoutOptions.Center,
                        TextTransform = TextTransform.Uppercase,
                        HorizontalTextAlignment = TextAlignment.Center
                    };

                    name_Label.SetBinding(Label.TextProperty, "name");

                    Label pantone_value_Label = new Label()
                    {
                        FontSize = 16,
                        TextColor = Color.WhiteSmoke,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center
                    };

                    pantone_value_Label.SetBinding(Label.TextProperty,
                        new Binding("pantone_value" , BindingMode.OneWay,
                            null, null));

                    StackLayout body = new StackLayout()
                    {
                        VerticalOptions = LayoutOptions.Center,
                        Spacing = 5,
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        WidthRequest = 105,
                        MinimumWidthRequest = 105,
                        HeightRequest = 105,
                        MinimumHeightRequest = 105,
                    };

                    body.SetBinding(StackLayout.BackgroundColorProperty, "color");

                    body.Children.Add(name_Label);
                    body.Children.Add(pantone_value_Label);

                    return new ViewCell
                    {
                        View = body
                    };
                })
            };

            listView.ItemTapped += (s, e) =>
            {
                var selectedItem = (ColorModel.Color)e.Item;
                Navigation.PushPopupAsync(new ColorPopup(selectedItem.id));

            };

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    listView
                }
            };
        }
    }
}

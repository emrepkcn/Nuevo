using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NuevoYazilim.Services;
using NuevoYazilim.Views;

namespace NuevoYazilim
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new Language();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

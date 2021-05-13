using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace WeatherCast
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            Weather col = await WeatherAPI.GetCurrentWeather("2960");
        }
    }
}

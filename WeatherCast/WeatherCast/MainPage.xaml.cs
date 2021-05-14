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
            WeatherCollection col = await WeatherAPI.GetWeatherForecast("34.9401", "36.3219");
        }
    }
}

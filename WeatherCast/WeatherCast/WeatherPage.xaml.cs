using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherCast
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();

            Appdata.CurrentCityChanged += ShowCurrentWeather;
            Appdata.FavoritesCitiesChanged += ShowForecastWeather;

            ShowCurrentWeather();
            ShowForecastWeather();
        }

        private async void ShowCurrentWeather()
        {
            Weather result = await WeatherAPI.GetCurrentWeather(Appdata.GetCurrentCity().Id);
            descriptionTxt.Text = result.Descriptions[0].Info.ToUpper();
            iconImg.Source = $"w{result.Descriptions[0].Icon}";
            cityTxt.Text = Appdata.GetCurrentCity().Name;
            temperatureTxt.Text = Convert.ToInt32(result.MainInfo.Temp).ToString();
            humidityTxt.Text = $"{result.MainInfo.Humidity}%";
            pressureTxt.Text = $"{result.MainInfo.Pressure} гПа";
            windTxt.Text = $"{result.Wind.Speed} м/с";
            cloudinessTxt.Text = $"{result.Clouds.All}%";

            dateTxt.Text = DateTime.Now.ToString("dddd, MMM dd", new CultureInfo("ru-RU")).ToUpper();

            
        }

        private async void ShowForecastWeather()
        {
            WeatherCollection result = await WeatherAPI.GetWeatherForecast(Appdata.GetCurrentCity().Coordinates.Lat.ToString(), Appdata.GetCurrentCity().Coordinates.Lon.ToString());


            
            dayOneTxt.Text = (DateTime.Now.AddDays(1)).ToString("dddd", new CultureInfo("ru-RU"));
            dateOneTxt.Text = (DateTime.Now.AddDays(1)).ToString("dd MMM", new CultureInfo("ru-RU"));
            iconOneImg.Source = $"w{result.Days[0].Weather[0].Icon}";
            tempOneTxt.Text = (Convert.ToInt32(result.Days[0].Temp.day)).ToString();

            dayTwoTxt.Text = (DateTime.Now.AddDays(2)).ToString("dddd", new CultureInfo("ru-RU"));
            dateTwoTxt.Text = (DateTime.Now.AddDays(2)).ToString("dd MMM", new CultureInfo("ru-RU"));
            iconTwoImg.Source = $"w{result.Days[1].Weather[0].Icon}";
            tempTwoTxt.Text = (Convert.ToInt32(result.Days[1].Temp.day)).ToString();

            dayThreeTxt.Text =(DateTime.Now.AddDays(3)).ToString("dddd", new CultureInfo("ru-RU"));
            dateThreeTxt.Text = (DateTime.Now.AddDays(3)).ToString("dd MMM", new CultureInfo("ru-RU"));
            iconThreeImg.Source = $"w{result.Days[2].Weather[0].Icon}";
            tempThreeTxt.Text = (Convert.ToInt32(result.Days[2].Temp.day)).ToString();

            dayFourTxt.Text = (DateTime.Now.AddDays(4)).ToString("dddd", new CultureInfo("ru-RU"));
            dateFourTxt.Text = (DateTime.Now.AddDays(4)).ToString("dd MMM", new CultureInfo("ru-RU"));
            iconFourImg.Source = $"w{result.Days[3].Weather[0].Icon}";
            tempFourTxt.Text = (Convert.ToInt32(result.Days[3].Temp.day)).ToString();
        }

    }
}
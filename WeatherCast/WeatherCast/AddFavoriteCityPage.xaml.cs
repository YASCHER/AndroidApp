using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherCast
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFavoriteCityPage : ContentPage
    {
        public ObservableCollection<City> FindedCities { get; set; }

        public AddFavoriteCityPage()
        {
            InitializeComponent();
            FindedCities = new ObservableCollection<City>();
            this.BindingContext = this;
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CityCollection cityCollection = await WeatherAPI.FindCity(e.NewTextValue);
                FindedCities.Clear();
                foreach (City city in cityCollection.Cities)
                {
                    FindedCities.Add(city);
                }
            }
            catch
            {
                FindedCities.Clear();
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Appdata.FavoritesCities.Add((City)e.Item);
            await Navigation.PopAsync();
        }
    }
}
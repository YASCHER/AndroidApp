using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherCast
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        public List<City> FavoritesCities { get; set; }
        
        public FavoritesPage()
        {
            InitializeComponent();
            FavoritesCities = Appdata.FavoritesCities;
            this.BindingContext = this;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFavoriteCityPage());
        }

        private async void TapOnCity(object sender, ItemTappedEventArgs e)
        {
            //((MainPage)(Parent)).CurrentPage = ((MainPage)(Parent)).Children[0];
            await DisplayAlert($"{((City)e.Item).Id}", "You have been alerted", "OK");
        }

      
    }
}
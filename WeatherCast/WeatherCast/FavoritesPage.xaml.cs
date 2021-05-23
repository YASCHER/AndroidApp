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
    public partial class FavoritesPage : ContentPage
    {
        public ObservableCollection<City> FavoritesCities { get; set; }
        
        public FavoritesPage()
        {
            InitializeComponent();

            Appdata.FavoritesCitiesChanged += Appdata_FavoritesCitiesChanged;

            FavoritesCities = new ObservableCollection<City>(Appdata.GetFavoritesCities());
            
            this.BindingContext = this;
            
        }

        private void Appdata_FavoritesCitiesChanged()
        {
            FavoritesCities.Clear();
            List<City> cities = Appdata.GetFavoritesCities();
            foreach (City city in cities)
            {
                FavoritesCities.Add(city);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFavoriteCityPage());
        }

        private void TapOnCity(object sender, ItemTappedEventArgs e)
        {
            Appdata.SetCurrentCity(((City)e.Item));

            ((ListView)sender).SelectedItem = null;

            ((MainPage)Parent.Parent).CurrentPage = ((MainPage)Parent.Parent).Children[0];

        }

      
    }
}
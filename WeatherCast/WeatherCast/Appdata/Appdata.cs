using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherCast
{
    static class Appdata
    {
        public static City CurrentCity { get; set; }

        public static List<City> FavoritesCities { get; set; }

        public static void Save()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "currentCity");
            string data = JsonConvert.SerializeObject(CurrentCity);

            File.WriteAllText(path, data);

            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favoritesCities");
            data = JsonConvert.SerializeObject(FavoritesCities);

            File.WriteAllText(path, data);
        }

        public static void Load()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "currentCity");
                string data = File.ReadAllText(path);

                CurrentCity = JsonConvert.DeserializeObject<City>(data);


                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favoritesCities");
                data = File.ReadAllText(path);

                FavoritesCities = JsonConvert.DeserializeObject<List<City>>(data);
            }
            catch (FileNotFoundException)
            {
                CurrentCity = new City() { };//сделать москву

                FavoritesCities = new List<City>();

                FavoritesCities.Add(CurrentCity);
            }
        }
    }
}

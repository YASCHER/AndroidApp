﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WeatherCast
{

    static class Appdata
    {

        private static City CurrentCity { get; set; }

        private static List<City> FavoritesCities { get; set; }

        public static event Action CurrentCityChanged;

        public static event Action FavoritesCitiesChanged;

        static Appdata() {
            Appdata.Load();
            FavoritesCitiesChanged += Save;
            CurrentCityChanged += Save;
        }

        public static void SetCurrentCity(City city)
        {
            CurrentCity = city;
            if (CurrentCityChanged != null)
            {
                CurrentCityChanged();
            }
        }

        public static City GetCurrentCity()
        {
            return CurrentCity;
        }

        public static void AddFavoriteCity(City city)
        {
            FavoritesCities.Add(city);
            if (FavoritesCitiesChanged != null)
            {
                FavoritesCitiesChanged();
            }
        }

        public static void DeleteFavoriteCity(string id)
        {
            City city = FavoritesCities.Where(x => x.Id == id).First();
            FavoritesCities.Remove(city);
            if (FavoritesCitiesChanged != null)
            {
                FavoritesCitiesChanged();
                
            }
        }

        public static List<City> GetFavoritesCities()
        {
            return FavoritesCities;
        }

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
                CurrentCity = new City() { Id= "524894", Name="Москва" };
                CurrentCity.Coordinates = new CityCoordinates() { Lat = 55.7617, Lon = 37.6067 };
                CurrentCity.SysInfo = new SysInfo() { Country="RU" };



                FavoritesCities = new List<City>();

                FavoritesCities.Add(CurrentCity);


            }
        }
    }
}

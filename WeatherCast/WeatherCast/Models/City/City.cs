using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    public class City
    {
        private string name;

        [JsonProperty("id")]
        public string Id { get; set; } // habr почему мы никогда не должны использовать MongoDB

        [JsonProperty("name")]
        public string Name { 
            get {
                return name.ToUpper();
            } 
            set {
                name = value;
            } 
        }

        [JsonProperty("coord")]
        public CityCoordinates Coordinates {get; set;}

        [JsonProperty("sys")]
        public SysInfo SysInfo { get; set; }
    }
}

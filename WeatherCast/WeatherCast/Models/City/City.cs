using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class City
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public CityCoordinates Coordinates {get; set;}

        [JsonProperty("sys")]
        public SysInfo SysInfo { get; set; }
    }
}

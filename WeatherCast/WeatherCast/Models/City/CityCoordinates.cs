using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class CityCoordinates
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }
}

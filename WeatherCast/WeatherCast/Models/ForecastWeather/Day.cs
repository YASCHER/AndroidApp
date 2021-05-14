using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class Day
    {
        [JsonProperty("temp")]
        public Temp Temp { get; set; }

        [JsonProperty("feels_like")]
        public FeelTemp FeelTemp { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("weather")]
        public Description[] Weather { get; set; }


    }
}

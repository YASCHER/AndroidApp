using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("gust")]
        public double Gust { get; set; }

        [JsonProperty("deg")]
        public int Deg { get; set; }
    }
}

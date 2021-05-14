using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class FeelTemp
    {
        [JsonProperty("day")]
        public double day { get; set; }
    }
}

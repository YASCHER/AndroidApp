using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class WeatherCollection
    {
        [JsonProperty("daily")]
        public List<Day> Days { get; set; }
    }
}

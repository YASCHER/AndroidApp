using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}

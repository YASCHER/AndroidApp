using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WeatherCast
{
    public class Temp
    {
        [JsonProperty("day")]
        public double day { get; set; }
    }
}

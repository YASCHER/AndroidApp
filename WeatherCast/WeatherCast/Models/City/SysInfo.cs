using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    public class SysInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}

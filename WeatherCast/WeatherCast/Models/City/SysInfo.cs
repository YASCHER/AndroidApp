using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class SysInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}

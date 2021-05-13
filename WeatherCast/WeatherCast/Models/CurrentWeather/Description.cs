using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class Description
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Info { get; set; }
    }
}

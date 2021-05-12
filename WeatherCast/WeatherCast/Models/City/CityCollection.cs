using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class CityCollection
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("list")]
        public List<City> Cities { get; set; }
    }
}

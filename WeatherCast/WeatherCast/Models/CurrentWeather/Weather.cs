using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class Weather
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("weather")]
        public Description[] Descriptions { get; set; }

        [JsonProperty("main")]
        public MainInfo MainInfo { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        public DateTime Date { get; set; }

        public Weather()
        {
            Date = DateTime.Now;
        }
        
    }
}

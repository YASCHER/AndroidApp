using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherCast
{
    class WeatherAPIResponse
    {
        public string ResponseText { get; private set; }

        public bool Successful { get; private set; }

        public WeatherAPIResponse(string responseText, bool successful)
        {
            ResponseText = responseText;
            Successful = successful;
        }
    }
}

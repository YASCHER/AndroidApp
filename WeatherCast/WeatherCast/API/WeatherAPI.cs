using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCast
{

    enum RequestType
    {
        CurrentWeather,
        DailyForecast,
        Find
    }

    static class WeatherAPI
    {
        private static string Host { get; set; }
        private static string AppId { get; set; }

        static WeatherAPI()
        {
            Host = "https://api.openweathermap.org/data/2.5/";
            AppId = "f5973b31423ae9ca4a83203dee0449fc";
        }

        private static async Task<WeatherAPIResponse> Get(RequestType requestType, NameValueCollection parameters)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = Host;

                switch(requestType)
                {
                    case RequestType.CurrentWeather:
                        {
                            url += "weather?";
                            break;
                        }
                    case RequestType.DailyForecast:
                        {
                            url += "onecall?";
                            break;
                        }
                    case RequestType.Find:
                        {
                            url += "find?";
                            break;
                        }
                }

                foreach (string key in parameters.AllKeys)
                {
                    url += key + "=" + parameters[key] + "&";
                }

                HttpResponseMessage request = await client.GetAsync(url);

                if (request.IsSuccessStatusCode)
                {
                    return new WeatherAPIResponse(await request.Content.ReadAsStringAsync(), true);
                }
                else
                {
                    return new WeatherAPIResponse(request.ReasonPhrase, false);
                }

            }
        }

        public static async Task<CityCollection> FindCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new Exception("Название города пустое");
            }

            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("q",city);
            parameters.Add("appid", AppId);
            parameters.Add("type", "like");
            parameters.Add("sort", "population");
            parameters.Add("cnt", "5");
            parameters.Add("lang", "ru");

            WeatherAPIResponse weatherAPIResponse = await Get(RequestType.Find, parameters);

            if (weatherAPIResponse.Successful)
            {
                CityCollection cityCollection = JsonConvert.DeserializeObject<CityCollection>(weatherAPIResponse.ResponseText);
                return cityCollection;
            }
            else
            {
                throw new Exception("Ошибка запроса");
            }
        }
    }
}

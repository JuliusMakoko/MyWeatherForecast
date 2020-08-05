using MyWeather.Models;
using System.Net.Http;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace MyWeather.Services
{
    public enum Units
    {
        Imperial,
        Metric
    }

    public class WeatherService
    {
       
        //const string WeatherCoordinatesUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units={2}&appid=fc9f6c524fc093759cd28d41fda89a1b";
        const string WeatherCoordinatesUri = "http://api.openweathermap.org/data/2.5/weather?lat=&lon={lon}&appid=81f882b652fc019407c3bd1c7ebcd4f5";
         const string WeatherCityUri = "http://api.openweathermap.org/data/2.5/weather?q={0}&units={1}&appid=81f882b652fc019407c3bd1c7ebcd4f5";
        //const string WeatherCityUri = "http://api.openweathermap.org/data/2.5/weather?q=Pretoria&units=metric&cnt=1&APPID=81f882b652fc019407c3bd1c7ebcd4f5";
         const string ForecaseUri = "http://api.openweathermap.org/data/2.5/forecast?id={0}&units={1}&appid=81f882b652fc019407c3bd1c7ebcd4f5";
       // const string ForecastUri = "http://api.openweathermap.org/data/2.5/forecast?q=Pretoria&appid=81f882b652fc019407c3bd1c7ebcd4f5";

        public async Task<WeatherRoot> GetWeather(double latitude, double longitude, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherCoordinatesUri, latitude, longitude, units.ToString().ToLower());
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherRoot>(json);
            }

        }

        public async Task<WeatherRoot> GetWeather(string city, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherCityUri, city, units.ToString().ToLower());
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherRoot>(json);
            }

        }

        public async Task<WeatherForecastRoot> GetForecast(int id, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(ForecaseUri, id, units.ToString().ToLower());
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherForecastRoot>(json);
            }

        }
    }
}

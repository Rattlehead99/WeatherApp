using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers;

public class AcuWeatherHelper
{
    public const string ApiKey = "YP64OkOvi9ATjiwvu2OcIDCFjusXtcUH";
    
    public const string BaseUrl = "http://dataservice.accuweather.com/";
    public const string AutocompleteEndpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";

    public const string ConditionsEndpoint = "currentconditions/v1/{0}?apikey={1}";

    public static async Task<List<City>?> GetCities(string query)
    {
        List<City>? cities = new List<City>();

        string url = BaseUrl + string.Format(AutocompleteEndpoint, ApiKey, query);

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            //The type is based on the JSON file itself, in this case a list/array of cities.
            cities = JsonConvert.DeserializeObject<List<City>>(json);
        }
        return cities;
    }

    public static async Task<WeatherConditions> GetWeatherConditions(string cityKey)
    {
        WeatherConditions? weatherConditions = new WeatherConditions();

        string url = BaseUrl + string.Format(ConditionsEndpoint, cityKey, ApiKey);

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            //The type is based on the JSON file itself, in this case a list/array of weather conditions.
            weatherConditions = (JsonConvert.DeserializeObject<List<WeatherConditions>>(json)).FirstOrDefault();
        }

        return weatherConditions;
    }
}
using System.Diagnostics;
using System.Text.Json;
using WeatherApp.NETMAUI.Models;

namespace WeatherApp.NETMAUI.Services
{
    public class WeatherService
    {
        HttpClient _client;
        public WeatherService()
        {
            _client = new HttpClient();
        }
        public async Task<CurrentWeather> GetCurrentWeather(string request)
        {
            CurrentWeather currentWeather = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    currentWeather = JsonSerializer.Deserialize<CurrentWeather>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return currentWeather;
        }
    }
}

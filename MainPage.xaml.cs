using WeatherApp.NETMAUI.Models;
using WeatherApp.NETMAUI.Services;

namespace WeatherApp.NETMAUI;

public partial class MainPage : ContentPage
{
    Coordinates locationCoords = null;
    LocalizationService _localizationService;
    WeatherService _weatherService;
    public MainPage()
    {
        InitializeComponent();
        _localizationService = new LocalizationService();
        _weatherService = new WeatherService();
    }

    private async void ButtonClicked(object sender, EventArgs e)
    {
        locationCoords = await _localizationService.GetLocation();
        CurrentWeather currentWeather = await _weatherService.GetCurrentWeather(GenerateRequest(API.OpenWeatherAPILink));
        BindingContext = currentWeather;
    }

    private string GenerateRequest(string endpoint)
    {
        string requestUri = endpoint;
        requestUri += $"weather?lat={locationCoords.Latitude}&lon={locationCoords.Longitude}";
        requestUri += $"&appid={API.OpenWeatherAPIKey}";
        return requestUri;
    }
}


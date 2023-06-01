using WeatherApp.NETMAUI.Models;
using WeatherApp.NETMAUI.Services;

namespace WeatherApp.NETMAUI;

public partial class MainPage : ContentPage
{
    Coordinates locationCoords = null;
    CurrentWeather currentWeather = null;
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
        currentWeather = await _weatherService.GetCurrentWeather(GenerateRequest(API.OpenWeatherAPILink));
        currentWeather.weather[0].icon = RenameImage(currentWeather.weather[0].icon);
        BindingContext = currentWeather;
    }

    private string GenerateRequest(string endpoint)
    {
        string requestUri = endpoint;
        requestUri += $"weather?lat={locationCoords.Latitude}&lon={locationCoords.Longitude}";
        requestUri += $"&appid={API.OpenWeatherAPIKey}";
        return requestUri;
    }

    private string RenameImage(string imageName)
    {
        string validName = imageName;
        if (validName[validName.Length - 1] == 'd')
        {
            return "d" + validName;
        }
        else
        {
            return "n" + validName;
        }
    }
}


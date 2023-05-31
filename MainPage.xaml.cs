using WeatherApp.NETMAUI.Models;
using WeatherApp.NETMAUI.Services;

namespace WeatherApp.NETMAUI;

public partial class MainPage : ContentPage
{
    LocalizationService _localizationService;
    public MainPage()
    {
        InitializeComponent();
        _localizationService = new LocalizationService();
    }

    private async void ButtonClicked(object sender, EventArgs e)
    {
        Coordinates locationCoords = await _localizationService.GetLocation();
        BindingContext = locationCoords;
    }
}


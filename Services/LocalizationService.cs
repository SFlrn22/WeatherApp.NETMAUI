using System.Diagnostics;

namespace WeatherApp.NETMAUI.Services
{
    public class LocalizationService
    {
        public LocalizationService()
        {

        }
        public async Task<Models.Coordinates> GetLocation()
        {
            Models.Coordinates coordinates = new Models.Coordinates();
            try
            {
                var request = new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.Medium);
                var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    coordinates.Latitude = location.Latitude;
                    coordinates.Longitude = location.Longitude;
                }
                else
                {
                    coordinates.Latitude = 0;
                    coordinates.Longitude = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            return coordinates;
        }
    }
}

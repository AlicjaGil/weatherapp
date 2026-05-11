using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;


namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string API_KEY = "ca0f01be9c1baf26e94e863b8768886c";

        public async Task<string> GetWeather(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric";

            try
            {
                var response = await _httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"Błąd API: {response.StatusCode}\n{content}";
                }

                return content;
            }
            catch (Exception ex)
            {
                return $"Wyjątek: {ex.Message}";
            }
        }
    }
}

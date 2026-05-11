using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _service = new WeatherService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(string country, string city)
        {
            var data = await _service.GetWeather(city);

            ViewBag.Data = data;
            ViewBag.City = city;

            return View("Result");
        }
    }
}

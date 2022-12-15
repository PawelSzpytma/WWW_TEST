using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromQuery] RequestSearch? request)
        {
            var list = Enumerable.Range(0, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.Date,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[index]
            }).ToList();
            
            if(!string.IsNullOrEmpty(request.searchRequest))
            {
                list = list.Where(c => c.Summary.Contains(request.searchRequest)).ToList();
            }


            return list;
        }
    }
}
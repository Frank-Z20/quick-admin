using Microsoft.AspNetCore.Mvc;
using quick_admin_server_net.Enties;
using quick_admin_server_net.Services;
using Serilog;

namespace Quick.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        /*
                private readonly ILogger _logger;

                public WeatherForecastController(ILogger logger)
                {
                    _logger = logger;
                }*/

        private readonly IUserService _userService;

        public WeatherForecastController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public User Get()
        {
            //if(_userService.GetById(123) = null)
            //Log.Debug("ab");
            return _userService.GetById(123);
            /*return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}
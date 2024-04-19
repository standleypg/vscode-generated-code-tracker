using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Requests;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
   private readonly ILogger<WeatherForecastController> _logger;
    private readonly ISender _sender;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherService wheatherService, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public async Task<IResult> GetAsync(GetWeatherForecast request)
    {
        var response= await _sender.Send(new WeatherRequest { city = request.city, days = request.days });
        return response;
    }
}

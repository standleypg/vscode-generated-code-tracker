using MediatR;
using server.Requests;
using server.Services;

namespace server.Handlers;

public class WeatherForecastHandler:IRequestHandler<WeatherRequest, IResult>
{
    private readonly WeatherService _weatherService;

    public WeatherForecastHandler(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IResult> Handle(WeatherRequest request, CancellationToken cancellationToken)
    {
        var forecast =  await _weatherService.Get(request.city, request.days);
        return Results.Ok(forecast);
    }
}

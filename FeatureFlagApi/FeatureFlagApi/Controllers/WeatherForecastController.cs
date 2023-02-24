using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagApi.Controllers;

[ApiController]
[Route("weatherForecast")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IFeatureManager _featureManager;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
        IFeatureManager featureManager)
    {
        _logger = logger;
        _featureManager = featureManager;
    }

    [HttpGet]
    public async Task<string> GetAvailableForecasts()
    {
        // A (stupid) example on how to use feature check inside code
        
        var info = "Here you can fetch short term forecasts";
        if (await _featureManager.IsEnabledAsync(FeatureFlags.LongTermForecast))
        {
            info += ", and now even long term ones!";
        }
        return info;
    }

    [HttpGet("shortTerm")]
    public IEnumerable<WeatherForecast> GetShortTermForecast()
    {
        return Enumerable.Range(1, 3).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet("longTerm")]
    [FeatureGate(FeatureFlags.LongTermForecast)]
    public IEnumerable<WeatherForecast> GetLongTermForecast()
    {
        return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
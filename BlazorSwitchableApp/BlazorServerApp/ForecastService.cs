using BlazorServerApp.Controllers;
using BlazorWasmApp.Shared;

namespace BlazorServerApp
{
  public class ForecastService : IForecastService
  {
    public ForecastService(WeatherForecastController service)
    {
      Service = service;
    }

    public WeatherForecastController Service { get; set; }

    public Task<WeatherForecast[]?> Get()
    {
      return Task.FromResult(Service.Get());
    }
  }
}

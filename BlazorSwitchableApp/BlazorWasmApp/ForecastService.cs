using BlazorWasmApp.Shared;
using System.Net.Http.Json;

namespace BlazorWasmApp.Client
{
  public class ForecastService : IForecastService
  {
    public ForecastService(HttpClient http)
    {
      Http = http;
    }

    public HttpClient Http { get; set; }

    public async Task<WeatherForecast[]?> Get()
    {
      return await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
  }
}

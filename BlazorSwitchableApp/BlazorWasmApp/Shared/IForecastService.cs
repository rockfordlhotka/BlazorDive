namespace BlazorWasmApp.Shared
{
  public interface IForecastService
  {
    Task<WeatherForecast[]?> Get();
  }
}

namespace BlazorState.Services
{
  public class Session : Dictionary<string, object>
  {
    public Session()
    {
      Add("value", 0);
    }
  }
}

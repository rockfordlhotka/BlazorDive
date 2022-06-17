using System.Collections.Concurrent;

namespace LabStatus.Data
{
  public static class LabStatusDb
  {
    public readonly static object SyncKey = new();

    public readonly static List<string> Labs = new List<string>
    {
      { "Lab00 - verify tools" },
      { "Lab01 - aspnetcore in docker" },
      { "Lab02 - aspnetcore in Azure" },
      { "Lab03 - example running in docker-compose" },
      { "Lab04 - install rabbitmq in kubernetes" },
      { "Lab05 - example running in kubernetes" }
    };

    public readonly static List<string> CurrentUsers = new List<string>();

    public readonly static ConcurrentDictionary<string, List<int>> LabStatus = new ConcurrentDictionary<string, List<int>>();
  }
}

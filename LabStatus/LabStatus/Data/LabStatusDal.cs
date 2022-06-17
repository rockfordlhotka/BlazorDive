namespace LabStatus.Data
{
  public class LabStatusDal
  {
    public List<string> GetLabs()
    {
      lock (LabStatusDb.SyncKey)
      {
        return LabStatusDb.Labs.ToList();
      }
    }

    public Dictionary<string, int> GetUserStatus(string user)
    {
      lock (LabStatusDb.SyncKey)
      {
        var userExists = LabStatusDb.CurrentUsers.Where(r => r == user).Any();
        if (!userExists)
          AddUser(user);

        var userData = LabStatusDb.LabStatus.Where(r => r.Key == user).FirstOrDefault().Value;
        var result = new Dictionary<string, int>();
        int i = 0;
        foreach (var item in GetLabs())
          result.Add(item, userData[i++]);
        return result;
      }
    }

    public void UpdateStatus(string user, string itemName, int status)
    {
      lock (LabStatusDb.SyncKey)
      {
        var index = -1;
        foreach (var item in LabStatusDb.Labs)
        {
          index++;
          if (item == itemName)
            break;
        }
        var userData = LabStatusDb.LabStatus.Where(r => r.Key == user).First().Value;
        userData[index] = status;
      }
    }

    public void AddUser(string user)
    {
      lock (LabStatusDb.SyncKey)
      {
        var exists = LabStatusDb.CurrentUsers.Where(r => r == user).Any();
        if (!exists)
          LabStatusDb.CurrentUsers.Add(user);
        LabStatusDb.LabStatus.TryAdd(user, new List<int> { 0, 0, 0, 0, 0, 0 });
      }
    }

    public void RemoveUser(string user)
    {
      lock (LabStatusDb.SyncKey)
      {
        var exists = LabStatusDb.CurrentUsers.Where(r => r == user).Any();
        if (exists)
        {
          List<int> x;
          LabStatusDb.LabStatus.TryRemove(user, out x);
          LabStatusDb.CurrentUsers.Remove(user);
        }
      }
    }

    public List<string> GetUsers()
    {
      lock (LabStatusDb.SyncKey)
      {
        return LabStatusDb.CurrentUsers.ToList();
      }
    }

    public Dictionary<string, List<int>> GetAllData()
    {
      lock (LabStatusDb.SyncKey)
      {
        var result = new Dictionary<string, List<int>>();
        foreach (var item in LabStatusDb.LabStatus)
          result.Add(item.Key, item.Value.ToList());
        return result;
      }
    }
  }
}

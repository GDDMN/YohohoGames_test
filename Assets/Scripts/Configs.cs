using UnityEngine;
using System.Collections.Generic;

public class Configs : Singleton<Configs>
{
  [SerializeField] private ItemsConfigs _configs;

  public ItemConfig GetItemConf(ItemType Type)
  {
    return  _configs.AllConfigs.Find(i => i.Data.Type == Type);
  }
}

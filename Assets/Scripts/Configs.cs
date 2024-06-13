using UnityEngine;
using System.Collections.Generic;

public class Configs : Singleton<Configs>
{
  [SerializeField] private List<ItemConfig> _items;

  public ItemConfig GetItemConf(ItemType Type)
  {
    return _items.Find(i => i.Data.Type == Type);
  }
}

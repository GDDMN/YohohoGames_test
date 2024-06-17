using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsCongfigs", menuName = "Configs/ItemsCongfigs")]
public class ItemsConfigs : ScriptableObject
{
  public List<ItemConfig> AllConfigs;
}

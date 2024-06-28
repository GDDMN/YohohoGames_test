using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemGeneratorComponent
{
  public float GenerationTime;
  public List<ItemType> AvaliableTypes;
  public List<ItemComponent> Items;
  public Transform SpawnPoint;
  public int MaxItemsCount;
  [HideInInspector] public int ItemsCount;
}

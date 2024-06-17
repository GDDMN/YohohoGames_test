using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;
using System;

public class ItemGenerationSystem : IEcsRunSystem
{
  private readonly EcsWorld _world = null;
  private readonly EcsFilter<ItemGeneratorComponent> _filter = null;

  private float _time;
  private Transform _spawnPoint;
  private int _itemsCount = 0;

  public void Run()
  {
    foreach(var generator in _filter)
    {
      ref var generatorComponent = ref _filter.Get1(generator);

      float geneationTime = generatorComponent.GenerationTime;
      List<ItemType> avaliableTypes = generatorComponent.AvaliableTypes;
      Transform spawnPoint = generatorComponent.SpawnPoint;
      int maxItemsCount = generatorComponent.MaxItemsCount;
      generatorComponent.ItemsCount = _itemsCount;

      if (_itemsCount >= maxItemsCount)
        return;

      _spawnPoint = spawnPoint;
      _time -= Time.deltaTime;

      if (_time > 0)
        return;

      ItemType randomType = (ItemType)UnityEngine.Random.Range(0, avaliableTypes.Count + 1);
      ItemData data = Configs.Instance.GetItemConf(randomType).Data;

      GameObject item = Resources.Load<GameObject>(data.WayToPrefab);
      GameObject.Instantiate(item.transform, spawnPoint.position, Quaternion.identity);

      _time = generatorComponent.GenerationTime;
      _itemsCount++;
    }
  }

}


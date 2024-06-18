using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;
using System;

public class ItemGenerationSystem : IEcsRunSystem, IEcsInitSystem
{
  private readonly EcsWorld _world = null;
  private readonly EcsFilter<ItemGeneratorComponent> _filter = null;

  private float _time;
  private Vector3 _spawnPoint;
  private int _itemsCount = 0;

  public void Init()
  {
    foreach(var generator in _filter)
    {
      ref var generatorComponent = ref _filter.Get1(generator);
      _spawnPoint = generatorComponent.SpawnPoint.position;
      _time = generatorComponent.GenerationTime;
    }
  }

  public void Run()
  {
    foreach(var generator in _filter)
    {
      ref var generatorComponent = ref _filter.Get1(generator);
      List<ItemType> avaliableTypes = generatorComponent.AvaliableTypes;
      
      int maxItemsCount = generatorComponent.MaxItemsCount;
      generatorComponent.ItemsCount = _itemsCount;

      if (_itemsCount >= maxItemsCount)
        return;

      _time -= Time.deltaTime;

      if (_time > 0)
        return;

      ItemType randomType = (ItemType)UnityEngine.Random.Range(0, avaliableTypes.Count);
      ItemData data = Configs.Instance.GetItemConf(randomType).Data;

      InitItem(data, _spawnPoint);

      _time = generatorComponent.GenerationTime;
      _itemsCount++;
    }
  }

  private void InitItem(ItemData data, Vector3 spawnPosition)
  {
    GameObject prefab = Resources.Load<GameObject>(data.WayToPrefab);
    GameObject item = UnityEngine.Object.Instantiate(prefab, spawnPosition, Quaternion.identity);

    EcsEntity itemEntity = _world.NewEntity();
    SetCmponents(itemEntity);

    ref var itemComponent = ref itemEntity.Get<ItemComponent>();

    _spawnPoint = item.transform.GetChild(1).position;
  }

  private void SetCmponents(EcsEntity entity)
  {
    entity.Get<ItemComponent>();
  }

}


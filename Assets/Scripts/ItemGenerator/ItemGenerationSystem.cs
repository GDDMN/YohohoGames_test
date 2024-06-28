using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;
using System;

public class ItemGenerationSystem : IEcsRunSystem, IEcsInitSystem
{
  private readonly EcsWorld _world = null;
  private readonly EcsFilter<ItemGeneratorComponent> _filter = null;
  
  private float _time;
  //private Vector3 _spawnPoint;
  private int _itemsCount = 0;
  private Transform _parent;

  public void Init()
  {
    foreach(var generator in _filter)
    {
      ref var generatorComponent = ref _filter.Get1(generator);
      _time = generatorComponent.GenerationTime;
    }
  }

  public void Run()
  {
    foreach(var generator in _filter)
    {
      ref var generatorComponent = ref _filter.Get1(generator);

      List<ItemType> avaliableTypes = generatorComponent.AvaliableTypes;
      Transform parent = generatorComponent.SpawnPoint;
      
      int maxItemsCount = generatorComponent.MaxItemsCount;
      generatorComponent.ItemsCount = _itemsCount;
      Vector3 spawnPoint = generatorComponent.SpawnPoint.position;

      if (_itemsCount >= maxItemsCount)
        return;

      _time -= Time.deltaTime;

      if (_time > 0)
        return;

      ItemType randomType = (ItemType)UnityEngine.Random.Range(0, avaliableTypes.Count);
      ItemData data = Configs.Instance.GetItemConf(randomType).Data;

      ItemComponent itemComponent = InitItem(data, spawnPoint, parent);

      generatorComponent.SpawnPoint.position = spawnPoint;
      generatorComponent.Items.Add(itemComponent);

      _time = generatorComponent.GenerationTime;
      _itemsCount++;
    }
  }

  private ItemComponent InitItem(ItemData data, Vector3 spawnPosition, Transform parent)
  {
    GameObject prefab = Resources.Load<GameObject>(data.WayToPrefab);
    GameObject item = UnityEngine.Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
    item.transform.SetParent(parent);

    EcsEntity itemEntity = _world.NewEntity();
    SetCmponents(itemEntity);

    ref var itemComponent = ref itemEntity.Get<ItemComponent>();
    spawnPosition = item.transform.GetChild(1).position;

    return itemEntity.Get<ItemComponent>();
  }

  private void SetCmponents(EcsEntity entity)
  {
    entity.Get<ItemComponent>();
  }

}


using Leopotam.Ecs;
using UnityEngine;

sealed public class MovementControllerSystem : IEcsRunSystem
{
  private readonly EcsWorld _world = null;
  private readonly EcsFilter<ModelComponent, MovabelComponent, DirectionCmponent, PlayerTag> _movableFilter = null;
  
  public void Run()
  {
    Debug.Log("Movement Controller Run");
    foreach(var i in _movableFilter)
    {
      ref var modelComponent = ref _movableFilter.Get1(i);
      ref var movableComponent = ref _movableFilter.Get2(i);
      ref var directionComponent = ref _movableFilter.Get3(i);

      ref var direction = ref directionComponent.Direction;
      ref var transform = ref modelComponent.ModelTransform;

      ref var characterController = ref movableComponent.CharacterController;
      ref var speed = ref movableComponent.Speed;

      var rawDirection = (transform.right * direction.x) + (transform.forward * direction.y);
      characterController.Move(rawDirection * speed);

    }
  }

}


using Leopotam.Ecs;
using UnityEngine;

sealed public class MovementControllerSystem : IEcsRunSystem
{
  private readonly EcsWorld _world = null;
  private readonly EcsFilter<ModelComponent, MovabelComponent, DirectionCmponent, PlayerTag> _movableFilter = null;

  
  public void Run()
  {
    foreach(var i in _movableFilter)
    {
      ref var modelComponent = ref _movableFilter.Get1(i);
      ref var movableComponent = ref _movableFilter.Get2(i);
      ref var directionComponent = ref _movableFilter.Get3(i);

      ref var direction = ref directionComponent.Direction;
      ref var transform = ref modelComponent.ModelTransform;
      ref var rotatableTransform = ref modelComponent.RotatableTransform;

      ref var characterController = ref movableComponent.CharacterController;
      ref var speed = ref movableComponent.Speed;

      var rawDirection = (transform.right * direction.x) + (transform.forward * direction.y);

      characterController.Move(rawDirection * speed);
      Rotate(rotatableTransform, direction);
    }
  }

  private void Rotate(Transform transform, Vector2 direction)
  {
    if (direction == Vector2.zero)
      return;

    Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
    Vector3 lookDirection = (transform.position + moveDirection) - transform.position;

    Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    transform.rotation = rotation;
  }

}


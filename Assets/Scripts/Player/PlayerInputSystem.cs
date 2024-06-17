using Leopotam.Ecs;
using UnityEngine;

sealed public class PlayerInputSystem : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
{
  private readonly EcsWorld _world = null;
  private readonly EcsFilter<PlayerTag, DirectionCmponent> _directionFilter = null;

  private InputActions _inputActions;

  private Vector2 _direction;

  public void Init()
  {
    _inputActions = new InputActions();
    _inputActions.Enable();
  }

  public void Destroy()
  {
    _inputActions.Disable();
  }

  public void Run()
  {
    foreach(var i in _directionFilter)
    {
      ref var directionComponent = ref _directionFilter.Get2(i);
      ref var direction = ref directionComponent.Direction;


      SetDirection();
      direction = _direction;
    }
  }

  private void SetDirection()
  {
    _direction = _inputActions.Player.Move.ReadValue<Vector2>();
  }
}


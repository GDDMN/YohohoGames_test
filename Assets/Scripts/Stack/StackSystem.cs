using Leopotam.Ecs;

public class StackSystem : IEcsRunSystem
{
  private EcsWorld _world = null;
  private EcsFilter<StackComponent> _filter = null;

  public void Run()
  {
  }
}

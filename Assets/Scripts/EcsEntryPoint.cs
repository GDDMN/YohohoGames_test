using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class EcsEntryPoint : MonoBehaviour
{
  private EcsWorld world;
  private EcsSystems systems;

  private void Start()
  {
    world = new EcsWorld();
    systems = new EcsSystems(world);


    systems.ConvertScene();
    
    AddInjections();
    AddOneFrames();
    AddSystems();
    
    systems.Init();
  }

  private void AddInjections()
  {

  }

  private void AddSystems()
  {
    systems.
      Add(new PlayerInputSystem()).
      Add(new MovementControllerSystem());
  }

  private void AddOneFrames()
  {

  }


  private void Update()
  {
    systems.Run();
  }

  private void OnDestroy()
  {
    if (systems == null)
      return;

    systems.Destroy();
    systems = null;
    world.Destroy();
    world = null;
  }


}

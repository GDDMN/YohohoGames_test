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
    
    AddSystems();
    AddOneFrames();
    AddInjections();
    
    systems.Init();
  }

  private void AddInjections()
  {

  }

  private void AddSystems()
  {

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
    world.Destroy();
    world = null;
  }


}

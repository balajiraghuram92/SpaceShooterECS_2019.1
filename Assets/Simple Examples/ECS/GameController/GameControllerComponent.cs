using Unity.Entities;

namespace ECS_Simple
{
     public struct GameControllerComponent : IComponentData
     {
          public int Countx;
          public int CountY;

          public Entity Prefab;
     }
}

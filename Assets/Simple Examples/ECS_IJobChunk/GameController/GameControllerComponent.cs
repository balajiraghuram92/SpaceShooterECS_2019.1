using Unity.Entities;

public struct GameControllerComponent : IComponentData
{
     public int Countx;
     public int CountY;

     public Entity Prefab;
}

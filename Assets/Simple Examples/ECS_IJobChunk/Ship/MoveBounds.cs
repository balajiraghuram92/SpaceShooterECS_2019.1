 using Unity.Entities;

namespace ECS_IJobChunk
{
     public struct MoveBounds : IComponentData
     {
          public float topBounds;
          public float bottomBounds;
     }
}

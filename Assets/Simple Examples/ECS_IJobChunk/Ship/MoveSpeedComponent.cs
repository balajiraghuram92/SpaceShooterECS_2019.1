using Unity.Entities;
using System;

namespace ECS_IJobChunk
{
[Serializable]
     public struct MoveSpeedComponent: IComponentData
     {
          public float value;
     }
}


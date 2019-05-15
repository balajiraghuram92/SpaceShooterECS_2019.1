using Unity.Entities;
using System;

namespace ECS_Simple
{
     [Serializable]
     public struct shipMovementComponent : IComponentData
     {
          public float movespeed ;
     }
}

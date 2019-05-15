using UnityEngine;
using  Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Burst;

namespace ECS_Simple
{
    public class GameControllerSystem : ComponentSystem
    { 
         protected override void OnUpdate()
        {
            Entities.ForEach((ref GameControllerComponent moveSpeed,ref Translation position,ref Rotation rotation) =>
            {
                 
            }); 
        }
    }
}

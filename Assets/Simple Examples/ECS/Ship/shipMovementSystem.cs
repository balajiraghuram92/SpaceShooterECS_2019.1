using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms; 

namespace ECS_Simple
{
    public class shipMovementSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref shipMovementComponent moveSpeed,ref shipMovementBounds moveBounds,ref Translation position,ref Rotation rotation) =>
            {
                Debug.Log("Speed : "+ moveSpeed.movespeed + "  Bounds : " + moveBounds.topBounds + "  |  " + moveBounds.bottomBounds);
                var deltaTime = Time.deltaTime;
                float3 localPos = position.Value;
                localPos += math.forward(rotation.Value) * moveSpeed.movespeed * Time.deltaTime;
                if(localPos.z > moveBounds.topBounds)
                    localPos.z = moveBounds.bottomBounds;

               position.Value = localPos;
                
                
            }); 
        }
    }
}

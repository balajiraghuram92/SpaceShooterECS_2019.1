using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

namespace ECS_Simple
{
    [RequiresEntityConversion]
    public class shipMovementEntity : MonoBehaviour,IConvertGameObjectToEntity
    {
        public float _moveSpeed;
        public float _topBounds;

        public float _bottomBounds;
         public void Convert(Entity entity,EntityManager dstManager,GameObjectConversionSystem conversionSystem)
         {
             var data1 = new shipMovementComponent
             {
                 movespeed = _moveSpeed
             };

             var data2 = new shipMovementBounds
             {
                 topBounds = _topBounds,
                 bottomBounds = _bottomBounds
             };

             dstManager.AddComponentData(entity,data1);
             dstManager.AddComponentData(entity,data2);
         }
    }
}

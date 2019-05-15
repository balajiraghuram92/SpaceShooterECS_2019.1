using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace ECS_IJobChunk
{
    public class moveSpeedEntity : MonoBehaviour,IConvertGameObjectToEntity
    {
        public float _value;
        public float _topBounds;
        public float _bottomBounds;
        public void Convert(Entity entity,EntityManager dstManager,GameObjectConversionSystem conversionSystem)
        {
            var data1 = new MoveSpeedComponent
            {
                value  = _value
            };

            var data2 = new MoveBounds
            {
                topBounds = _topBounds,
                bottomBounds = _bottomBounds
            };
            
            dstManager.AddComponentData(entity,data1);
            dstManager.AddComponentData(entity,data2);


        }
    }
}

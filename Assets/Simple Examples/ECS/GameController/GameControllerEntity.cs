using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

namespace ECS_Simple
{
    public class GameControllerEntity : MonoBehaviour,IDeclareReferencedPrefabs,IConvertGameObjectToEntity
    {
        public GameObject Prefab;
        public int Countx;
        public int County;
        
        public float speed;
        public float topBounds;
        public float bottomBounds;

        public float leftBounds;

        public float rightBounds;
        public void DeclareReferencedPrefabs(List<GameObject> gameobjects)
        {
            gameobjects.Add(Prefab);
        }

        public void Convert(Entity entity,EntityManager dstManager,GameObjectConversionSystem conversionSystem)
        {
            Entity _shipEntity = conversionSystem.GetPrimaryEntity(Prefab);
            var data = new GameControllerComponent{
            Prefab = _shipEntity,
            Countx = Countx,
            CountY = County
            };

            dstManager.AddComponentData(entity,data);

            var shipEntityDetails = new shipMovementEntity{
                _moveSpeed = speed,
                _topBounds = topBounds,
                _bottomBounds = bottomBounds
            };            

            dstManager.SetComponentData(_shipEntity,new shipMovementEntity{
                _moveSpeed = speed,
                _topBounds = topBounds,
                _bottomBounds = bottomBounds
            }            ); 
        }
    }
}

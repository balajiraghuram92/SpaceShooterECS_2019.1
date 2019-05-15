using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class GameControllerEntity : MonoBehaviour,IDeclareReferencedPrefabs,IConvertGameObjectToEntity
{
    public GameObject Prefab;
    public int Countx;

    public int County;

    public void DeclareReferencedPrefabs(List<GameObject> gameobjects)
    {
        gameobjects.Add(Prefab);
    }

    public void Convert(Entity entity,EntityManager dstManager,GameObjectConversionSystem conversionSystem)
    {
        var data = new GameControllerComponent{
        Prefab = conversionSystem.GetPrimaryEntity(Prefab),
        Countx = Countx,
        CountY = County
        };

        dstManager.AddComponentData(entity,data);
    }
}

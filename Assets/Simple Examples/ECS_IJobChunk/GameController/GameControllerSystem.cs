using UnityEngine;
using  Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Burst;

public class GameControllerSystem : JobComponentSystem
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }


    struct GameControllerJob : IJobForEachWithEntity<GameControllerComponent,LocalToWorld>
    {
        public EntityCommandBuffer.Concurrent commandBuffer;

        public void Execute(Entity entity,int index,[ReadOnly]ref GameControllerComponent spawner,[ReadOnly] ref LocalToWorld location)
        {
            for( int i =0 ; i < spawner.Countx;i++)
            {
                for(int j =0 ;j< spawner.CountY;j++)
                {
                  //  Debug.Log("Index : " + index);
                    var instance = commandBuffer.Instantiate(index,spawner.Prefab);
                   // Debug.Log("Old Transform : "+ position.Value + "  i : " + i + "  j : " + j);
                    var position = math.transform(location.Value,new float3(i*1.3f,noise.cnoise(new float2(i,j)*0.21f)*2,j*1.3f));
                  //  Debug.Log("New Transoform : " + location + "  i : " + i + "  j : " + j);
                    commandBuffer.SetComponent(index,instance,new Translation{Value = position});
                }
            }
            commandBuffer.DestroyEntity(index,entity);
        }
    } 

    protected override JobHandle OnUpdate(JobHandle inputDeps) 
    {
        var job = new GameControllerJob
        {
            commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent()
        }.Schedule(this,inputDeps);
        m_EntityCommandBufferSystem.AddJobHandleForProducer(job);
        return job;
    }
}

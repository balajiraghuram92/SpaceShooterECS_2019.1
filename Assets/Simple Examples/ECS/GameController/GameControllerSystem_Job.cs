// using UnityEngine;
// using  Unity.Entities;
// using Unity.Jobs;
// using Unity.Mathematics;
// using Unity.Transforms;
// using Unity.Collections;
// using Unity.Burst;

// namespace ECS_Simple
// {
//     public class GameControllerSystem_Job : JobComponentSystem
//     { 
//          BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
        
 
       
//         struct spwanJob : IJobForEachWithEntity<GameControllerComponent,LocalToWorld>
//         {
//             public    Unity.Mathematics.Random randomFloat;
//             public EntityCommandBuffer.Concurrent commandBuffer;
           
//             public void Execute(Entity entity,int index,[ReadOnly] ref GameControllerComponent gameController,[ReadOnly] ref LocalToWorld position)
//            {
             
//             for (int i = 0; i < gameController.enemyCount; i++)
//             {
//                 float xVal = randomFloat.NextFloat(gameController.LeftBounds, gameController.RightBounds);
//                 float zVal = randomFloat.NextFloat(0f, 10f);

//                 var instance = commandBuffer.Instantiate(index,gameController.Prefab);

//                 var location =  new float3(xVal, -136,gameController.TopBounds+zVal); 
//                 commandBuffer.SetComponent(index,instance, new Translation { Value = location});
//                 commandBuffer.SetComponent(index,instance, new Rotation { Value = new quaternion(0, 1, 0, 0) }); 
//                 commandBuffer.AddComponent(index,instance,new shipMovementComponent{ movespeed = gameController.MoveSpeed });
//                 commandBuffer.AddComponent(index,instance,new shipMovementBounds{  topBounds = gameController.TopBounds, bottomBounds = gameController.BottomBounds });
                
//             } 
//              commandBuffer.DestroyEntity(index, entity);
             
//             if(GameManager.Instance != null)
//                 GameManager.Instance.count += gameController.enemyCount;
//            }
//         }

//         protected override void OnCreate()
//         {            
//             m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
//         }

//         bool createShips = true;
//         protected override JobHandle OnUpdate(JobHandle inputDeps)
//         {
            
//             var job = new spwanJob
//             {
//                 randomFloat = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(0,10000)),
//                 commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent()
//             }.Schedule(this,inputDeps);

            
//             m_EntityCommandBufferSystem.AddJobHandleForProducer(job);
         
//             return job;
//         }
//     }
// }

 using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS_IJobChunk
{
    public class MovementSystem : JobComponentSystem
    {  
        
        
        EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(typeof(Translation),typeof(Rotation),ComponentType.ReadOnly<MoveSpeedComponent>(),ComponentType.ReadOnly<MoveBounds>());
        }

        [BurstCompile]
        struct MovementJob : IJobChunk
        { 

            public float deltaTime;

            public ArchetypeChunkComponentType<Translation> translationType;
            [ReadOnly]
            public ArchetypeChunkComponentType<Rotation> rotationType;
            
            [ReadOnly]
            public ArchetypeChunkComponentType<MoveSpeedComponent> moveSpeedComponentType;
        
            [ReadOnly]
            public ArchetypeChunkComponentType<MoveBounds> moveBoundsType;
        
            public void Execute(ArchetypeChunk chunk,int cuhnkIndex,int firstEntityIndex)
            {
                var chunkTranslation = chunk.GetNativeArray(translationType);
                var chunkrotation = chunk.GetNativeArray(rotationType);
                var chunkMoveSpeed = chunk.GetNativeArray(moveSpeedComponentType);
                var chunkMoveBounds = chunk.GetNativeArray(moveBoundsType);

                for(var i =0;i<chunk.Count;i++)
                {
                    var transform = chunkTranslation[i];
                    var rotation = chunkrotation[i];
                    var moveSpeed = chunkMoveSpeed[i];
                    var moveBounds = chunkMoveBounds[i];

                    //Debug.Log("Old Transform : " + transform.Value);
                    float3 value = transform.Value;

                    value += deltaTime * moveSpeed.value * math.forward(rotation.Value);

                    if(value.x < moveBounds.bottomBounds)
                        value.z = moveBounds.topBounds;
                    // Debug.Log("O Transform : " + value);
                    // transform.Value = value;   
                    chunkTranslation[i] = new Translation
                    {
                        Value = value
                    };


                }
            }
        
        }


        protected override JobHandle OnUpdate(JobHandle inputDesc)
        {
            
            var _translationType = GetArchetypeChunkComponentType<Translation>(false);
            var _rotationType = GetArchetypeChunkComponentType<Rotation>(false);
            var _moveSpeedType = GetArchetypeChunkComponentType<MoveSpeedComponent>(true);
            var _moveBounds = GetArchetypeChunkComponentType<MoveBounds>(true);
            
            MovementJob job = new MovementJob
            {
                translationType = _translationType,
                rotationType = _rotationType,
                moveSpeedComponentType = _moveSpeedType,
                moveBoundsType = _moveBounds,
                deltaTime = Time.deltaTime
            };

            return job.Schedule(m_Group,inputDesc);
        }
        
    }
}

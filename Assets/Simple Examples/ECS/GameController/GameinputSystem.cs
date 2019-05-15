using Unity.Burst;
using Unity.Jobs;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;

public class GameinputSystem : ComponentSystem
{
     EntityQuery inputSystem;

     protected override void OnCreateManager()
     {
         base.OnCreateManager();
         inputSystem = GetEntityQuery(typeof(GameinputComponent));
     }

     protected override void OnUpdate()
     {
         ArchetypeChunkComponentType<GameinputComponent> inputData = GetArchetypeChunkComponentType<GameinputComponent>(false);
         NativeArray<ArchetypeChunk> inputdataChunk = inputSystem.CreateArchetypeChunkArray(Allocator.TempJob);
         if(inputdataChunk.Length == 0)
         {
             inputdataChunk.Dispose();
             return;
         }

         for(int chunkIndex = 0;chunkIndex < inputdataChunk.Length;chunkIndex++)
         {
             ArchetypeChunk chunk = inputdataChunk[chunkIndex];
             int dataCount = chunk.Count;

             NativeArray<GameinputComponent> inputDataArray = chunk.GetNativeArray(inputData);

             for( int dataindex = 0; dataindex < dataCount;dataindex++)
             {
                 GameinputComponent gameInput = inputDataArray[dataindex];

                 bool keyPress = Input.GetKeyDown(KeyCode.C);

                 gameInput.keyPress = keyPress ? 1 : 0;
                  
             }
         }
         inputdataChunk.Dispose();

     }
}

using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS
{
    public partial struct TowerCreateSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<TowerCreator>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var towerCreator = SystemAPI.GetSingleton<TowerCreator>();
            var cubePrefab = towerCreator.CubePrefab;

            int height = towerCreator.Height;
            int width = towerCreator.Width;
            int length = towerCreator.Length;

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int l = 0; l < length; l++)
                    {
                        if (l != 0 && w != 0 && l != length - 1 && w != width - 1)
                        {
                            continue;
                        }

                        var cubeEntity = state.EntityManager.Instantiate(cubePrefab);

                        state.EntityManager.SetComponentData(cubeEntity, new LocalTransform
                        {
                            Position = new float3(l, h + 0.5f, w),
                            Rotation = quaternion.identity,
                            Scale = 1f
                        });
                    }
                }
            }
        }
    }
}

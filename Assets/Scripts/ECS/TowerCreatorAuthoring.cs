using Unity.Entities;
using UnityEngine;

namespace ECS
{
    public class TowerCreatorAuthoring : MonoBehaviour
    {
        public GameObject CubePrefab;
        public int Length;
        public int Width;
        public int Height;

        class Baker : Baker<TowerCreatorAuthoring>
        {
            public override void Bake(TowerCreatorAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                AddComponent(entity, new TowerCreator
                {
                    CubePrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic),
                    Length = authoring.Length,
                    Width = authoring.Width,
                    Height = authoring.Height,
                });
            }
        }
    }

    public struct TowerCreator : IComponentData
    {
        public Entity CubePrefab;
        public int Length;
        public int Width;
        public int Height;
    }
}

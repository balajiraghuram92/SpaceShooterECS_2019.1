 using Unity.Entities;

namespace ECS_Simple
{
    public struct shipMovementBounds : IComponentData
    {
        public float topBounds;
        public float bottomBounds;
    }
}

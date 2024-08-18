using FizzleTD.ECS.Components;
using MonoGame.Extended.ECS;

namespace FizzleTD.ECS.Entities;

public class Enemy
{
    protected Entity Entity { get; private set; }
    public Enemy(World world, EnemyComponent enemyComponent)
    {
        Entity = world.CreateEntity();
        Entity.Attach(enemyComponent);
    }
}

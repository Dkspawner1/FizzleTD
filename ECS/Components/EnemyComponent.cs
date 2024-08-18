using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.Graphics;
using System;

namespace FizzleTD.ECS.Components;

public class EnemyComponent(Texture2D texture, Transform2 transform)
{
    public Sprite Sprite => new(texture);
    public Transform2 Transform { get => transform; private set => Transform = value; }
    public float Speed = 5.25f;
    public Vector2 Direction;
    public Vector2 Destination;
  

    public bool CollidedWithTower;

    public void SetEnemyPath(Entity tower)
    {
        if (tower is null)
        {
            throw new ArgumentNullException(nameof(tower));
        }

        Destination = tower.Get<TowerComponent>().TowerCenter;
    }
}

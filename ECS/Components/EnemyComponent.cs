
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace FizzleTD.ECS.Components;

public class EnemyComponent(Texture2D texture, Transform2 transform)
{
    public Sprite Sprite => new(texture);
    public Transform2 Transform { get => transform; private set => Transform = value; }
    public float Speed;
    public bool CollidedWithTower;
}

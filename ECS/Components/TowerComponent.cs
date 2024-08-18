using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace FizzleTD.ECS.Components;
public class TowerComponent(Texture2D texture)
{
    public Sprite Sprite { get; private set; } = new(texture) { Origin = Vector2.Zero };
    public Transform2 Transform { get; set; } = new Transform2(Vector2.Zero, 0f, Vector2.One);
    public Vector2 TowerCenter;
}

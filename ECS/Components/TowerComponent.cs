using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace FizzleTD.ECS.Components;
public class TowerComponent(Texture2D texture)
{
    public Sprite Sprite { get => new(texture); }
    public Transform2 Transform { get; set; } = new Transform2(Vector2.Zero, 0f, Vector2.One);
    public Vector2 TowerCenter => CalculateTowerCenter(); 

    public Vector2 CalculateTowerCenter() => Transform.Position + (Sprite.TextureRegion.Bounds.Size.ToVector2() - Sprite.Origin) * Transform.Scale / 2;
}

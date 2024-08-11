using MonoGame.Extended;

namespace FizzleTD.ECS.Components;

public class CircleComponent(CircleF circle)
{
    public Color Color { get; set; }
    public byte Alpha { get; set; }
    public CircleF Circle { get; set; } = circle;
}

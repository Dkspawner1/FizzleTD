using FizzleTD.ECS.Components;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System;
using System.Diagnostics;

namespace FizzleTD.ECS.Entities;

public class Tower
{
    // The Entity representing this Tower in the ECS framework.
    protected Entity Entity { get; private set; }

    // Constructor to create a new Tower
    public Tower(World world, TowerComponent towerComponent)
    {
        // Create a new entity within the provided world.
        Entity = world.CreateEntity();

        // Calculate and set the tower's position to center it on the screen,
        // considering the sprite's origin and scale.
        towerComponent.Transform.Position = new Vector2(
            (Data.Window.Width - towerComponent.Sprite.TextureRegion.Width * towerComponent.Transform.Scale.X) / 2,
            (Data.Window.Height - towerComponent.Sprite.TextureRegion.Height * towerComponent.Transform.Scale.Y) / 2
        ) - towerComponent.Sprite.Origin * towerComponent.Transform.Scale;

        // Calculate the tower's center position, considering origin and scale.
        towerComponent.TowerCenter = towerComponent.Transform.Position +
         (towerComponent.Sprite.TextureRegion.Bounds.Size.ToVector2() - towerComponent.Sprite.Origin) * towerComponent.Transform.Scale / 2;

        // Attach the tower component to the entity.
        Entity.Attach(towerComponent);

        // Attach a circle component centered around the tower with a specified radius and color.
        var circleComponent = new CircleComponent(new CircleF(towerComponent.TowerCenter, 325f))
        {
            Color = Color.DarkRed,
            Alpha = 255 / 2 // Set the alpha to 50%.
        };

        Entity.Attach(circleComponent);
    }
}

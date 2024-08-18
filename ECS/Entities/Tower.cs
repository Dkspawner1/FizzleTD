using FizzleTD.ECS.Components;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System.Collections.Generic;

namespace FizzleTD.ECS.Entities;

public class Tower
{
    // The Entity representing this Tower in the ECS framework.
    protected Entity Entity { get; private set; }

    private static readonly Dictionary<double, byte> AlphaDict = new Dictionary<double, byte>()
        {
            { 100, 255 }, // 100% opacity
            { 85,  217 }, // 85% opacity
            { 75,  191 }, // 75% opacity
            { 50,  128 }, // 50% opacity
            { 25,   64 }, // 25% opacity
            { 0,    0 }   // 0% opacity (fully transparent)
        };

    // Constructor to create a new Tower
    public Tower(World world, TowerComponent towerComponent)
    {
        // Create a new entity within the provided world.
        Entity = world.CreateEntity();


        // Set the tower's position, considering the sprite's origin and scale
       towerComponent.Transform.Position = new Vector2(
            (Data.Window.Width - towerComponent.Sprite.TextureRegion.Width * towerComponent.Transform.Scale.X) / 2,
            (Data.Window.Height - towerComponent.Sprite.TextureRegion.Height * towerComponent.Transform.Scale.Y) / 2
        ) - towerComponent.Sprite.Origin * towerComponent.Transform.Scale;

        towerComponent.CalculateTowerCenter();

        // Attach components to the entity
        Entity.Attach(towerComponent); // Attach the Tower itself as a component if needed

        // Attach a circle component centered around the tower with a specified radius and color
        Entity.Attach(new CircleComponent(new CircleF(towerComponent.TowerCenter, 325f))
        {
            Color = Color.DarkRed,
            Alpha = AlphaDict[25] 
        });
    }
}

using FizzleTD.ECS.Components;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System;
using System.Diagnostics;

namespace FizzleTD.ECS.Entities;

public class Tower
{
    protected Entity Entity { get; private set; }
    public Tower(World world, TowerComponent towerComponent)
    {
        Entity = world.CreateEntity();

        // Tower's Position:
        towerComponent.Transform.Position = new Vector2(Data.Window.Width / 2 - towerComponent.Sprite.TextureRegion.Width / 2, Data.Window.Height / 2 - towerComponent.Sprite.TextureRegion.Height / 2);

        Entity.Attach(towerComponent);

        // Circle's Position: 
        var towerCenter = new Vector2(
               towerComponent.Transform.Position.X + towerComponent.Sprite.TextureRegion.Width / 2,
               towerComponent.Transform.Position.Y + towerComponent.Sprite.TextureRegion.Height / 2
           );

        Entity.Attach(new CircleComponent(new CircleF(towerCenter,325f)) { Color = Color.DarkRed, Alpha = 255 / 2 });
    }
}

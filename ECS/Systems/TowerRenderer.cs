using FizzleTD.ECS.Components;
using FizzleTD.ECS.Entities;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;
using System;
using System.Diagnostics;

namespace FizzleTD.ECS.Systems;

public class TowerRenderer : EntityDrawSystem
{
    private readonly SpriteBatch spriteBatch;
    private ComponentMapper<TowerComponent> towerComponentMapper;
    private ComponentMapper<CircleComponent> circleMapper;

    public TowerRenderer(SpriteBatch spriteBatch) : base(Aspect.All(typeof(CircleComponent), typeof(TowerComponent)))
    {
        this.spriteBatch = spriteBatch;
    }
    public override void Initialize(IComponentMapperService mapperService)
    {
        towerComponentMapper = mapperService.GetMapper<TowerComponent>();
        circleMapper = mapperService.GetMapper<CircleComponent>();
    }
    public override void Draw(GameTime gameTime)
    {
        foreach (var entity in ActiveEntities)
        {
            var tower = towerComponentMapper.Get(entity);
            var sprite = tower.Sprite;
            var transform = tower.Transform;

            var circle = circleMapper.Get(entity);
           
            DrawTower(tower.TowerCenter,sprite, transform);
            DrawCircle(circle);

        }
    }
    private void DrawTower(Vector2 center,Sprite sprite, Transform2 transform)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        sprite.Draw(spriteBatch, transform.Position, transform.Rotation, transform.Scale);

        Trace.WriteLine(center);
        spriteBatch.DrawRectangle(new RectangleF(center.X, center.Y, 100f, 100f), Color.Red, 2f);


        spriteBatch.End();
    }
    private void DrawCircle(CircleComponent circle)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.AnisotropicClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
        
        spriteBatch.DrawCircle(circle.Circle, 60, new Color(circle.Color,circle.Alpha), 1.5f);
        spriteBatch.End();

    }


}

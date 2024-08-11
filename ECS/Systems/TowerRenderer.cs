using FizzleTD.ECS.Components;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;
using System;

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

            var br = sprite.GetBoundingRectangle(transform);
            float sqrt = (float)Math.Sqrt((br.
                Width * br.Width + br.Height * br.Height) / 2); 
            circle.Circle = new CircleF(new Vector2(br.X /2 , br.Height / 2), sqrt);

            DrawTower(sprite, transform);
            DrawCircle(circle);

        }
    }
    private void DrawTower(Sprite sprite, Transform2 transform)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        sprite.Draw(spriteBatch, transform.Position, transform.Rotation, transform.Scale);
        spriteBatch.End();
    }
    private void DrawCircle(CircleComponent circle)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
        
        spriteBatch.DrawCircle(circle.Circle, 60, new Color(circle.Color,circle.Alpha), 1.5f);
        spriteBatch.End();

    }


}

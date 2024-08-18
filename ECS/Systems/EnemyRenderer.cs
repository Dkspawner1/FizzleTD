using FizzleTD.ECS.Components;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;

namespace FizzleTD.ECS.Systems;

public class EnemyRenderer : EntityDrawSystem
{
    private readonly SpriteBatch spriteBatch;
    private ComponentMapper<EnemyComponent> enemyComponentMapper;
    public EnemyRenderer(SpriteBatch spriteBatch) : base(Aspect.All(typeof(EnemyComponent)))
    {
        this.spriteBatch = spriteBatch;
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        enemyComponentMapper = mapperService.GetMapper<EnemyComponent>();
    }

    public override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,SamplerState.PointClamp);
        foreach (var entity in ActiveEntities)
        {
            var enemy = enemyComponentMapper.Get(entity);
            var sprite = enemy.Sprite;
            var transform = enemy.Transform;

            sprite.Draw(spriteBatch, transform.Position, transform.Rotation, transform.Scale);
        }
        spriteBatch.End();
    }
}

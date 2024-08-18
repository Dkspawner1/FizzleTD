using FizzleTD.ECS.Components;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System.Diagnostics;

namespace FizzleTD.ECS.Systems;

public class WaveSystem : EntityProcessingSystem
{
    private ComponentMapper<WaveComponent> waveComponentMapper;
    public WaveSystem() : base(Aspect.All(typeof(WaveComponent)))
    {

    }
    public override void Initialize(IComponentMapperService mapperService)
    {
        waveComponentMapper = mapperService.GetMapper<WaveComponent>();
    }
    public override void Process(GameTime gameTime, int entityId)
    {
        var wave = waveComponentMapper.Get(entityId);
        
        var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
      
        foreach (var enemy in wave.EnemyQueue)
        {
            var sprite = enemy.Sprite;
            var transform = enemy.Transform;
            


            transform.Position += new Vector2(speed + delta, transform.Position.Y);

            //Trace.WriteLine(transform.Position);

        }
    }
}

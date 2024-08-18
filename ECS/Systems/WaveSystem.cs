using FizzleTD.ECS.Components;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System;
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
            var normalizedSpeed = enemy.Speed + delta;

            var targetDestination = enemy.Destination;
            var enemyCenter = sprite.GetBoundingRectangle(transform).Center;

            var distance = Vector2.Distance(targetDestination, enemyCenter);

            if (distance >= 4f)
            {
                enemy.Direction = targetDestination - enemyCenter;
                enemy.Direction.Normalize();
                transform.Position += enemy.Direction * normalizedSpeed;
            }
            // Enemy has reached the tower
            else
            {
                Random r = new Random();
                

                transform.Position = new Vector2(NextDoubleLinear(r,0,Data.Window.Width), NextDoubleLinear(r,0,Data.Window.Height));
            }
            Trace.WriteLine(distance);
        }

    }
    private static float NextDoubleLinear(Random random, double min, double max)
    {
        return (float)(min + random.NextDouble() * (max - min));
    }
}

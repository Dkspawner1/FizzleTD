using FizzleTD.ECS.Components;
using MonoGame.Extended.ECS;

namespace FizzleTD.ECS.Entities;

public class Wave
{
    protected Entity Entity;
    public Wave(World world, WaveComponent waveComponent)
    {
        Entity = world.CreateEntity();
        Entity.Attach(waveComponent);
            
    }
}

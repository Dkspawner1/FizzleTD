
using FizzleTD.ECS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FizzleTD.ECS.Components;

public class WaveComponent(IEnumerable<EnemyComponent> enemyQueue)
{
    public Queue<EnemyComponent> EnemyQueue { get; } = new(enemyQueue);
    public int EnemyCount => enemyQueue.Count();
    public float EnemySpawnTimer;

}

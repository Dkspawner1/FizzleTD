using FizzleTD.ECS.Components;
using FizzleTD.ECS.Entities;
using FizzleTD.ECS.Systems;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System.Collections;
using System.Collections.Generic;

namespace FizzleTD.Scenes;

public class GameScene : SceneBase
{
    public GameScene(SpriteBatch spriteBatch) : base(spriteBatch)
    {
        world = new WorldBuilder()
            .AddSystem(new WaveSystem())
            .AddSystem(new TowerRenderer(spriteBatch))
            .AddSystem(new EnemyRenderer(spriteBatch))
            .Build();
    }

    public override void Initialize()
    {

    }

    public override void LoadContent(ContentManager Content)
    {
        var tower = new Tower(world, new TowerComponent(Content.Load<Texture2D>("textures/dorll")));
        
        var enemy0 = new EnemyComponent(Content.Load<Texture2D>("textures/dorll"), new Transform2());
        var enemyEntity0 = new Enemy(world, enemy0);

        List<EnemyComponent> wave0Enemies = [enemy0];

        var wave0 = new Wave(world, new WaveComponent(wave0Enemies));
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}

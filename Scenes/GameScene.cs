using FizzleTD.ECS.Components;
using FizzleTD.ECS.Entities;
using FizzleTD.ECS.Systems;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System;
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

        var enemy0 = new EnemyComponent(Content.Load<Texture2D>("textures/clubs-1"), new Transform2(new Vector2(100f,20f)));
        var enemyEntity0 = new Enemy(world, enemy0);

        var enemy1 = new EnemyComponent(Content.Load<Texture2D>("textures/clubs-1"), new Transform2(new Vector2(1000f, 800f)));
        var enemyEntity1 = new Enemy(world, enemy1);

        var enemy2 = new EnemyComponent(Content.Load<Texture2D>("textures/clubs-1"), new Transform2(new Vector2(500, 900)));
        var enemyEntity2 = new Enemy(world, enemy2);

        enemy0.SetEnemyPath(tower.Entity);
        enemy1.SetEnemyPath(tower.Entity);
        enemy2.SetEnemyPath(tower.Entity);

        List<EnemyComponent> wave0Enemies = [enemy0,enemy1,enemy2];

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

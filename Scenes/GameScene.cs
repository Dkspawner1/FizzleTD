using FizzleTD.ECS.Components;
using FizzleTD.ECS.Entities;
using FizzleTD.ECS.Systems;
using MonoGame.Extended;
using MonoGame.Extended.ECS;

namespace FizzleTD.Scenes;

public class GameScene : SceneBase
{
    public GameScene(SpriteBatch spriteBatch) : base(spriteBatch)
    {
        world = new WorldBuilder()
            .AddSystem(new TowerRenderer(spriteBatch))
            .Build();
    }

    public override void Initialize()
    {

    }

    public override void LoadContent(ContentManager Content)
    {
        var tower = new Tower(world, new TowerComponent(Content.Load<Texture2D>("textures/dorll")));
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

using MonoGame.Extended.ECS;

namespace FizzleTD.Scenes;

public class MenuScene : SceneBase
{
    public MenuScene(SpriteBatch spriteBatch) : base(spriteBatch)
    {
        world = new WorldBuilder().Build();
    }

    public override void Initialize()
    {

    }

    public override void LoadContent(ContentManager Content)
    {
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

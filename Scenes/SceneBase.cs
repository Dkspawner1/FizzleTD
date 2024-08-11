using MonoGame.Extended.ECS;
namespace FizzleTD.Scenes;
public abstract class SceneBase(SpriteBatch spriteBatch)
{
    private readonly SpriteBatch spriteBatch = spriteBatch;
    protected World world;
    public abstract void Initialize();
    public abstract void LoadContent(ContentManager Content);
    public virtual void Update(GameTime gameTime) => world.Update(gameTime);
    public virtual void Draw(GameTime gameTime) => world.Draw(gameTime);
}

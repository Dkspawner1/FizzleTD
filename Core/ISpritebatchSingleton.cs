
namespace FizzleTD.Core;

public interface ISpritebatchSingleton
{
    protected SpriteBatch SpriteBatch { get; }
}

public class SpritebatchSingleton : ISpritebatchSingleton
{
    public SpriteBatch SpriteBatch { get; protected set; }
    private SpritebatchSingleton(GraphicsDevice graphics) => SpriteBatch = new SpriteBatch(graphics);
    public static SpritebatchSingleton Create(GraphicsDevice graphics) => new SpritebatchSingleton(graphics);
}

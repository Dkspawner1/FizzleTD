using FizzleTD.Managers;
using System;
using System.Diagnostics;

namespace FizzleTD.Core;
public class Game1 : Game
{
    private  SceneManager sceneManager;
    public Game1()
    {
        _ = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = Data.Window.Width,
            PreferredBackBufferHeight = Data.Window.Height,
        };

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Window.Title = Data.Window.Title;
       
        sceneManager = new SceneManager(SpritebatchSingleton.Create(GraphicsDevice).SpriteBatch);

        sceneManager.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        sceneManager.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        sceneManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        sceneManager.Draw(gameTime);
        base.Draw(gameTime);
    }
}

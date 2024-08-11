
using FizzleTD.Scenes;
using System.Collections.Generic;
using System.Linq;
using static FizzleTD.Core.Data.Game;

namespace FizzleTD.Managers;

public class SceneManager
{
    public readonly Dictionary<SCENES, SceneBase> scenes;
    private SceneBase currentScene;
    public SceneManager(SpriteBatch spriteBatch)
    {
        scenes = new()
        {
            {SCENES.MENU, new MenuScene(spriteBatch)},
            {SCENES.GAME, new GameScene(spriteBatch)}
        };
        currentScene = scenes[SCENES.GAME];

    }
    public void Initialize()
    {
        foreach (var scene in scenes.Values)
            scene.Initialize();
    }
    public void LoadContent(ContentManager Content)
    {
        foreach (var scene in scenes.Values)
            scene.LoadContent(Content);
    }
    public void Update(GameTime gameTime)
    {
        currentScene?.Update(gameTime);
    }
    public void Draw(GameTime gameTime)
    {
        currentScene?.Draw(gameTime);
    }
}

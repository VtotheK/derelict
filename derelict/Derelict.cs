using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using derelict;
using derelict.ECS;
using derelict.Assets;

namespace derelict
{
    public class Derelict : Game
    {
        public static GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager gameManager;
        private GameState gameState;

        public Derelict()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            gameManager = new GameManager();
            gameState = new GameState
            {
                CurrentState = RunningState.StartUp
            };
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            graphicsDevice = GraphicsDevice;
            gameManager.LoadAssets();
            gameManager.SetPlayer(); //TODO Make this not shitty, prolly some UI
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keys = Keyboard.GetState().GetPressedKeys();
            gameManager.HandleInput(keys);
            gameManager.UpdateWorldState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var deltaTime = gameTime.ElapsedGameTime.Milliseconds;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            gameManager.DrawEntities(_spriteBatch, deltaTime);
            base.Draw(gameTime);
        }
    }
}
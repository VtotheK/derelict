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
        private AssetHandler assetHandler;

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
            assetHandler = new AssetHandler();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            graphicsDevice = GraphicsDevice;
            assetHandler.LoadAssetData();
            var spriteAsset = assetHandler.GetPlayerSpriteAsset();
            //TODO Change this implementation
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
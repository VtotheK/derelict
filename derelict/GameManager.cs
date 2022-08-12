using derelict.Levels;
using derelict.ECS;
using derelict.ECS.Components;
using derelict.Assets;
using derelict.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace derelict
{
    internal class GameManager
    {
        private Map currentMap;
        private MapManager mapManager;
        private AssetHandler assetHandler;
        private Entity Player { get; set; }
        private List<Entity> Entities { get; set; }
        public GameManager()
        {
            mapManager = new MapManager();
            assetHandler = new AssetHandler();
            currentMap = mapManager.GetInitialMap();
            Entities = new List<Entity>();
        }
        public void SetPlayer()
        {
            var playerSprite = assetHandler.GetPlayerSpriteAsset(); //TODO Shitty
            var player = new Entity();
            player.AttachComponents(
                new SpriteComponent
                {
                    Texture = playerSprite.ToTexture2D(),
                    SpriteSize = playerSprite.SpriteSize
                },
                new PositionComponent { EntityPosition = new Vector2(0.0f, 0.0f) },
                new PlayerComponent
                {
                    Health = 100,
                    Speed = 0.0f,
                    InputDirection = new Vector2(0.0f, 0.0f),
                });
            Player = player;
            Entities.Add(player);
        }

        public void LoadAssets() { assetHandler.LoadAssetData(); }

        public Map GetCurrentMap()
        {
            return currentMap;
        }

        internal void UpdateWorldState()
        {
        }

        public void HandleInput(Keys[] pressedKeys)
        {
            if(pressedKeys.Length == 0) { return; }
            float x = 0.0f, y = 0.0f;
            foreach(var key in pressedKeys)
            {
                //TODO Change value not hard coded
                if(key == Keys.W)
                {
                    y += 1.0f;
                }
                if(key == Keys.S)
                {
                    y -= 1.0f;
                }
                if(key == Keys.D)
                {
                    x += 1.0f;
                }
                if(key == Keys.A)
                {
                    x -= 1.0f;
                }
            }
            Player.GetComponent<PlayerComponent>().InputDirection = new Vector2(x, y);
        }

        internal void DrawEntities(SpriteBatch spriteBatch, int deltaTime)
        {
            spriteBatch.Begin();
            foreach(var entity in Entities)
            {
                entity.Render(spriteBatch, deltaTime);
            }
            spriteBatch.End();
        }
    }
}

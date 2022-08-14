using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using derelict.Levels;
using derelict.ECS;
using derelict.ECS.Components;
using derelict.ECS.System;
using derelict.Assets;
using derelict.Extensions;

namespace derelict.Engine
{
    public class GameEngine
    {
        private PlayerSystem PlayerSystem;
        private Map CurrentMap;
        private MapManager MapManager;
        private AssetHandler AssetHandler;
        private Entity Player { get; set; }
        private Dictionary<string, Entity> Entities { get; set; }
        private List<string> ActiveEntities { get; set; }
        public GameEngine()
        {
            MapManager = new MapManager();
            AssetHandler = new AssetHandler();
            CurrentMap = MapManager.GetInitialMap();
            Entities = new Dictionary<string, Entity>();
            ActiveEntities = new List<string>();
            PlayerSystem = new PlayerSystem();
        }
        public void SetPlayer()
        {
            var playerSprite = AssetHandler.GetPlayerSpriteAsset(); //TODO Shitty
            var player = new Entity();
            player.AttachComponents(
                new SpriteComponent(player)
                {
                    Texture = playerSprite.ToTexture2D(),
                    SpriteSize = playerSprite.SpriteSize
                },
                new PositionComponent(player) { EntityPosition = new Vector2(0.0f, 0.0f) },
                new PlayerComponent(player)
                {
                    Health = 100,
                    Speed = 0.0f,
                    InputDirection = new Vector2(0.0f, 0.0f),
                },
                new InputComponent(player)
                { 
                    IsInvertedYAxis = false
                });
            Player = player;
            Entities.Add(player.ID, player);
            ActiveEntities.Add(player.ID);
        }

        public void LoadAssets() { AssetHandler.LoadAssetData(); }

        public Map GetCurrentMap()
        {
            return CurrentMap;
        }

        internal void UpdateWorldState()
        {
            var pos = Player.GetComponent<PositionComponent>();
            var direction = Player.GetComponent<PlayerComponent>();
            pos.EntityPosition = new Vector2(pos.EntityPosition.X + direction.InputDirection.X,
                                             pos.EntityPosition.Y + direction.InputDirection.Y);
            foreach(var entity in Entities)
            {

            }
        }

        public void HandleInput(Keys[] pressedKeys)
        {
            if(pressedKeys.Length == 0) { return; }
            float x = 0.0f, y = 0.0f;
            foreach(var key in pressedKeys)
            {
                //TODO Change value not hard coded
                if(key == Keys.W || key == Keys.Up)
                {
                    y -= 1.0f;
                }
                if(key == Keys.S || key == Keys.Down)
                {
                    y += 1.0f;
                }
                if(key == Keys.D || key == Keys.Right)
                {
                    x += 1.0f;
                }
                if(key == Keys.A || key == Keys.Left)
                {
                    x -= 1.0f;
                }
            }
            Player.GetComponent<PlayerComponent>().InputDirection = new Vector2(x, y);
        }

        internal void DrawEntities(SpriteBatch spriteBatch, int deltaTime)
        {
            spriteBatch.Begin();
            foreach(var id in ActiveEntities)
            {
                Entities[id].Render(spriteBatch, deltaTime);
            }
            spriteBatch.End();
        }
    }
}

using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using derelict.Assets.Base;
using derelict.Extensions;

namespace derelict.Assets
{
    public class AssetHandler
    {
        readonly string AssetDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
        const string PLAYERASSETID = "player_";

        public List<SpriteAsset> SpriteAssets { get; set; }
        private Dictionary<string[], Action<string>> AssetHandlers = new Dictionary<string[], Action<string>>();

        public AssetHandler()
        {
            SpriteAssets = new List<SpriteAsset>();
            AssetHandlers.Add(new string[] { ".png", ".jpeg", ".jpg" }, LoadSprite);
            AssetHandlers.Add(new string[] { ".txt", ".doc", ".docx", ".md" }, LoadText);
        }

        public void LoadAssetData()
        {
            var files = Directory.GetFiles(AssetDataPath, "*", SearchOption.AllDirectories);

            foreach (var filePath in files)
            {
                var fileExtension = Path.GetExtension(filePath);
                foreach(var extensions in AssetHandlers.Keys)
                {
                    var extensionInKey = extensions
                        .Where(extension => extension == fileExtension)
                        .Any();
                    if(extensionInKey)
                    {
                        AssetHandlers[extensions].Invoke(filePath);
                    } 
                }
            }
        }

        private void LoadSprite(string filePath)
        {
            try
            {
                var asset = new SpriteAsset
                {
                    AssetType = AssetType.Sprite,
                    AssetPath = filePath,
                    IsPlayerAsset = IsPlayerAsset(filePath),
                    SpriteSize = SpriteAssetExtensions.GetSpriteAssetDimensions(filePath)
                };
                SpriteAssets.Add(asset);
                Debug.WriteLine($"Sprite {Path.GetFileNameWithoutExtension(filePath)} added to asset collection.");
            }
            catch(ArgumentException e)
            {
                Debug.WriteLine($"Could not read size of sprite file at ${filePath}.");
            }
        }

        private bool IsPlayerAsset(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath).Contains(PLAYERASSETID);
        }

        public SpriteAsset GetPlayerSpriteAsset()
        {
            return SpriteAssets.Where(a => a.IsPlayerAsset).FirstOrDefault();
        }

        private void LoadText(string obj)
        {
            Debug.WriteLine("Text loaded");
        }
    }
}

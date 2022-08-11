using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using derelict.Assets.Base;

namespace derelict.Assets
{
    public class AssetHandler
    {
        readonly string AssetDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");

        public List<Asset> Assets { get; set; }
        private static Dictionary<string[], Action<string>> AssetHandlers = new Dictionary<string[], Action<string>>()
        {
            { new string[]{ ".png", ".jpeg", ".jpg"} , LoadSprite },
            { new string[]{ ".txt", ".doc", ".docx", ".md"} , LoadText},
        };


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

        private static void LoadSprite(string dsfas)
        {
            Debug.WriteLine("Sprite loaded");
        }
        private static void LoadText(string obj)
        {
            Debug.WriteLine("Text loaded");
        }
    }
}

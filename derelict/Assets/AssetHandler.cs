using System;
using System.Collections.Generic;
using System.IO;
using derelict.Assets.Base;

namespace derelict.Assets
{
    public class AssetHandler
    {
        public List<Asset> Assets { get; set; }

        readonly string AssetDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
        private static Dictionary<string[], Action<string>> AssetHandlers = new Dictionary<string[], Action<string>>()
        {
            { new string[]{ ".png", ".jpeg", ".jpg"} , LoadSprite },
            { new string[]{ ".txt", ".doc", ".docx", ".md"} , LoadText},
        };


        public void LoadAssetData()
        {

        }

        private static void LoadSprite(string dsfas)
        {
        }
        private static void LoadText(string obj)
        {

        }
    }
}

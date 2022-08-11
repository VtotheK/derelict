using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.Assets.Base
{
    public enum AssetType
    {
        Sprite,
        SoundEffect,
        Animation,
        Text
    }
    public class Asset
    {
        public AssetType AssetType { get; init; }
        public string AssetPath { get; init; }
        public bool IsPlayerAsset { get; init; }
    }
}

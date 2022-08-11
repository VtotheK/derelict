using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using derelict.Assets.Base;

namespace derelict.Assets

{
    public class TextAsset : Asset
    {
        string Content { get; set; }

        public void ReadContent()
        {
            Content = File.ReadAllText(this.AssetPath);
        }
    }
}

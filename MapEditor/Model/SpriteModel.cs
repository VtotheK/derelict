using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MapEditor.Model
{
    public class SpriteModel
    {
        public Bitmap SpriteImage;
        public string Name { get; set; }
        public string Path { get; set; }
    }
}

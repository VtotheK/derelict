using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using MapEditor.Extensions;

namespace MapEditor.Service
{
    public class SpritesplitService
    {
        public BitmapImage CreatePreviewTilemap(BitmapImage bitmapImage, int spriteWidth, int spriteHeight)
        {
            if(bitmapImage.Width < spriteWidth) { throw new ArgumentException("Sprite width can't be larger than the tilemap width."); }
            if(bitmapImage.Height < spriteHeight) { throw new ArgumentException("Sprite height can't be larger than the tilemap height."); }
            Bitmap tileMap =  bitmapImage.ToBitmap();
            var graphics = Graphics.FromImage(tileMap);
            var pen = new Pen(Brushes.Black);
            graphics.DrawLine(pen, new Point(0, 0), new Point(50, 50));
            return tileMap.ToBitmapImage();
        }
    }
}

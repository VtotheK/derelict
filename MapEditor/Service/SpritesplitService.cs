using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;
using MapEditor.Extensions;
using MapEditor.Model;

namespace MapEditor.Service
{
    public class SpritesplitService
    {
        public BitmapImage CreatePreviewTilemap(BitmapImage bitmapImage, int spriteWidth, int spriteHeight)
        {
            if(bitmapImage.Width < spriteWidth) { throw new ArgumentException("Sprite width can't be larger than the tilemap width."); }
            if(bitmapImage.Height < spriteHeight) { throw new ArgumentException("Sprite height can't be larger than the tilemap height."); }

            Bitmap bitmap =  bitmapImage.ToBitmap();
            var rects = GetTilemapSplits(bitmap, spriteWidth, spriteHeight);

            CreatePreviewFromRectangles(bitmap, rects);

            return bitmap.ToBitmapImage();
        }

        public List<SpriteModel> GetSprites(BitmapImage originalTileMap, int spriteWidth, int spriteHeight)
        {
            if(originalTileMap.Width < spriteWidth) { throw new ArgumentException("Sprite width can't be larger than the tilemap width."); }
            if(originalTileMap.Height < spriteHeight) { throw new ArgumentException("Sprite height can't be larger than the tilemap height."); }

            var bitmap = originalTileMap.ToBitmap();
            var rects = GetTilemapSplits(bitmap, spriteWidth, spriteHeight);
            return GetSpritesFromTilemap(bitmap, rects);
        }
        
        private void CreatePreviewFromRectangles(Bitmap bitmap, List<Rectangle> rects)
        {
            var graphics = Graphics.FromImage(bitmap);
            var pen = new Pen(Brushes.Red);
            foreach(var rect in rects)
            {
                graphics.DrawRectangle(pen, rect);
            }
        }

        private List<Rectangle> GetTilemapSplits(Bitmap bitmap, int spriteWidth, int spriteHeight)
        {
            var rectangles = new List<Rectangle>();
            var currentHeight = 0;
            var currentWidth = 0;

            while(currentHeight + spriteHeight < bitmap.Height)
            {
                while(currentWidth + spriteWidth < bitmap.Width)
                {
                    rectangles.Add(new Rectangle(new Point { Y = currentHeight, X = currentWidth }, new Size(spriteWidth, spriteHeight)));
                    currentWidth += spriteWidth;
                }
                currentWidth = 0;
                currentHeight += spriteHeight;
            }
            return rectangles;
        }

        private List<SpriteModel> GetSpritesFromTilemap(Bitmap originalTileMap, List<Rectangle> rects)
        {
            var spriteModels = new List<SpriteModel>();
            var originalFormat = originalTileMap.PixelFormat;
            var seq = 0;
            foreach(var rect in rects)
            {
                spriteModels.Add(new SpriteModel
                {
                    SpriteImage = originalTileMap.Clone(rect, originalFormat),
                    Name = $"sprite_{seq.ToString()}"
                });
            }
            return spriteModels;
        }
    }
}

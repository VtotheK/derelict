using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;
using MapEditor.Model;
using MapEditor.Service;

namespace MapEditor.ViewModel
{
    public class SpriteSplitterViewModel
    {
        public int test = 0;
        public SpriteSplitterModel Model { get; private set; }
        private SpritesplitService splitService { get; set; }
        public SpriteSplitterViewModel() 
        {
            Model = new SpriteSplitterModel();
            splitService = new SpritesplitService();
        }

        public SpriteSplitterViewModel(SpriteSplitterModel model)
        {
            splitService = new SpritesplitService();
            Model = model;
        }

        public void CreatePreviewTilemap()
        {
            try
            {
                var tiles = splitService.CreatePreviewTilemap(Model.OriginalTileSet, Model.SpriteWidth ?? 0, Model.SpriteHeight ?? 0);
                Model.UITileSet = tiles;
            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }
        }
    }
}

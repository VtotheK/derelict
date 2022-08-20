using System;
using System.Diagnostics;
using System.Windows;
using MapEditor.Model;
using MapEditor.Service;

namespace MapEditor.ViewModel
{
    public class SpriteSplitterViewModel
    {
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
                Model.TileSet = splitService.CreatePreviewTilemap(Model.TileSet, Model.SheetWidth, Model.SpriteHeight ?? 0);

            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }
        }
    }
}

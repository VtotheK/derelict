using System;
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

            Model = model;
        }

        public void CreatePreviewTilemap()
        {
            var previewTilemap = splitService.CreatePreviewTilemap(Model.TileSet, Model.SheetWidth, Model.SpriteHeight);
        }
    }
}

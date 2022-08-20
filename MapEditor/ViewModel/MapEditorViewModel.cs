using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MapEditor.Model;
using MapEditor.Service;
using MapEditor.View;

namespace MapEditor.ViewModel
{
    public class MapEditorViewModel 
    {
        public MapEditorModel Model { get; private set; }
        public RelayCommand _spriteSheetOpenDialog;
        public MapEditorViewModel()
        {
            Model = new MapEditorModel();
            SpriteSheetOpenDialog = new RelayCommand(SpriteFileDialog);
        }

        public RelayCommand SpriteSheetOpenDialog { get => _spriteSheetOpenDialog; set => _spriteSheetOpenDialog = value; }

        public void SpriteFileDialog()
        {
            var sprites = DialogService.GetSprites();
            foreach(var sprite in sprites)
            {
                Model.Sprites.Add(sprite);
            }
        }
    }
}

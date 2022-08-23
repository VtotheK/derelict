using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Shapes;
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
        public MapEditorViewModel(MapEditorModel model)
        {
            Model = model;
            SpriteSheetOpenDialog = new RelayCommand(SpriteFileDialog);
        }

        public RelayCommand SpriteSheetOpenDialog { get => _spriteSheetOpenDialog; set => _spriteSheetOpenDialog = value; }

        public void SpriteFileDialog()
        {
            var spriteCollection = DialogService.GetSpriteCollection();
            if(spriteCollection == null) { return; }

            Model.SpriteCollections.Add(spriteCollection);
        }
        public void ResetMap()
        {
            if(Model.Map != null)
            {
                //TODO ask user confirmation
            }

            Model.Map = new Rectangle[Model.MapHeight, Model.MapWidth];
        }
    }
}

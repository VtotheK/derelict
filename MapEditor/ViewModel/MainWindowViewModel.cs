using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MapEditor.Model;
using MapEditor.Service;
using MapEditor.View;

namespace MapEditor.ViewModel
{
    public class MainWindowViewModel 
    {
        public List<SpriteModel> Sprites;
        public RelayCommand SpriteSheetOpenDialog;

        public MainWindowViewModel()
        {
            Sprites = new List<SpriteModel>();
            SpriteSheetOpenDialog = new RelayCommand(GetSpritesWithDialog);
        }

        private void GetSpritesWithDialog()
        {
            var sprites = DialogService.GetSprites();
        }
    }
}

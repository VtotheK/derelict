using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MapEditor.Model;
using MapEditor.Service;

namespace MapEditor.ViewModel
{
    public class MainWindowViewModel 
    {
        public List<Sprite> Sprites;
        public RelayCommand SpriteSheetOpenDialog;

        public MainWindowViewModel()
        {
            Sprites = new List<Sprite>();
            SpriteSheetOpenDialog = new RelayCommand(GetSpritesWithDialog);
        }

        private void GetSpritesWithDialog()
        {
            var sprites = DialogService.GetSprites();
        }
    }
}

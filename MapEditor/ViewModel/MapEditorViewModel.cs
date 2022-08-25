using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Shapes;
using MapEditor.Model;
using MapEditor.Service;
using MapEditor.View;


namespace MapEditor.ViewModel
{
    public delegate void MapChangedDelegate();
    public class MapEditorViewModel 
    {
        public event MapChangedDelegate NewMapEvent;

        public MapEditorModel Model { get; private set; }
        public RelayCommand _spriteSheetOpenDialog;
        public RelayCommand _newMapCommand;

        public RelayCommand SpriteSheetOpenDialog { get => _spriteSheetOpenDialog; set => _spriteSheetOpenDialog = value; }
        public RelayCommand NewMapCommand { get => _newMapCommand; set => _newMapCommand = value; }

        public MapEditorViewModel()
        {
            Model = new MapEditorModel();
            InitCommands();
            Subscribe();
        }
        public MapEditorViewModel(MapEditorModel model)
        {
            Model = model;
            InitCommands();
            Subscribe();
        }

        public void Subscribe()
        {
            Model.MapSizeChanged += OnMapSizeChanged;
        }

        public void InitCommands()
        {
            SpriteSheetOpenDialog = new RelayCommand(SpriteFileDialog);
            NewMapCommand = new RelayCommand(NewMapDialog);
        }

        private void NewMapDialog()
        {
            //TODO Invoke map changed delegate
            throw new NotImplementedException();
        }


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
            Model.Map = new Rectangle[Model.MapWidth, Model.MapHeight];
            NewMapEvent?.Invoke();
        }

        public void OnMapSizeChanged()
        {
            ResetMap();
        }
    }
}

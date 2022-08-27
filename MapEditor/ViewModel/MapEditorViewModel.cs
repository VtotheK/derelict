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
        public event MapChangedDelegate ResizeMapEvent;

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
            Model.EditorMap.MapSizeChanged += OnMapSizeChanged;
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
            if(Model.EditorMap.Map != null)
            {
                //TODO ask user confirmation
            }
            Model.EditorMap.Map = new Rectangle[Model.EditorMap.MapWidth, Model.EditorMap.MapHeight];
            NewMapEvent?.Invoke();
        }

        public void OnMapSizeChanged()
        {
            var map = new Rectangle[Model.EditorMap.MapWidth, Model.EditorMap.MapHeight];
            for (int y = 0; y < Model.EditorMap.MapHeight; ++y)
            {
                for (int x = 0; x < Model.EditorMap.MapWidth; ++x)
                {
                    map[x, y] = Model.EditorMap.Map[x, y];
                }
            }
            ResizeMapEvent?.Invoke();
        }
    }
}

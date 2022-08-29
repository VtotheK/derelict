using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Shapes;
using MapEditor.Model;
using MapEditor.Service;
using MapEditor.View;
using System.Linq;
using MapEditor.Command;

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
        public RemoveSpriteCommand _removeSpriteFromSpriteCollection;

        public RelayCommand SpriteSheetOpenDialog { get => _spriteSheetOpenDialog; set => _spriteSheetOpenDialog = value; }
        public RelayCommand NewMapCommand { get => _newMapCommand; set => _newMapCommand = value; }
        public RemoveSpriteCommand RemoveSpriteFromSpriteCollectionCommand { get => _removeSpriteFromSpriteCollection; set => _removeSpriteFromSpriteCollection = value; }

        public MapEditorViewModel()
        {
            Model = new MapEditorModel();
            InitCommands();
            SubscribeEvents();
        }
        public MapEditorViewModel(MapEditorModel model)
        {
            Model = model;
            InitCommands();
            SubscribeEvents();
        }

        public void SubscribeEvents()
        {
            Model.EditorMap.MapSizeChanged += OnMapSizeChanged;
        }

        public void InitCommands()
        {
            SpriteSheetOpenDialog = new RelayCommand(SpriteFileDialog);
            NewMapCommand = new RelayCommand(NewMapDialog);
            RemoveSpriteFromSpriteCollectionCommand = new RemoveSpriteCommand(RemoveSprite);
        }

        private void NewMapDialog()
        {
            //TODO Invoke map changed delegate
            throw new NotImplementedException();
        }

        private void RemoveSprite(object model)
        {
            var spriteModel = (SpriteModel)model;
            if (spriteModel == null)
                throw new ArgumentException(nameof(SpriteModel));
           
            foreach (var collection in Model.SpriteCollections)
            {
                var toDelete = collection.Sprites.Where(sprite => sprite.Id == spriteModel.Id).FirstOrDefault();
                if(toDelete != null)
                {
                    collection.Sprites.Remove(toDelete);
                    break;
                }
            }
        }

        public void SpriteFileDialog()
        {
            var spriteCollection = DialogService.GetSpriteCollection();
            if(spriteCollection == null) { return;}

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
            var newMap = new Rectangle[Model.EditorMap.MapWidth, Model.EditorMap.MapHeight];
            MapEditorService.CopyMap(Model.EditorMap.Map, newMap);
            Model.EditorMap.Map = newMap;
            ResizeMapEvent?.Invoke();
        }
    }
}

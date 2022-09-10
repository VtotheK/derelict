using System;
using MapEditor.Model;
using MapEditor.Service;
using System.Linq;
using MapEditor.Command;
using MapEditor.Constants;
using System.Drawing;

namespace MapEditor.ViewModel
{
    public delegate void MapChangedDelegate();
    public class MapEditorViewModel 
    {
        public event MapChangedDelegate NewMapEvent;
        public event MapChangedDelegate ResizeMapEvent;

        public MapEditorModel Model { get; private set; }
        private RelayCommand _spriteSheetOpenDialog;
        private RelayCommand _newMapCommand;
        private RelayCommand _adjustMapSize;
        private RelayCommand _adjustSpriteSize;
        private RemoveSpriteCommand _removeSpriteFromSpriteCollection;

        public RelayCommand SpriteSheetOpenDialog { get => _spriteSheetOpenDialog; set => _spriteSheetOpenDialog = value; }
        public RelayCommand NewMapCommand { get => _newMapCommand; set => _newMapCommand = value; }
        public RelayCommand AdjustMapSizeCommand { get => _adjustMapSize; set => _adjustMapSize = value; }

        public void LoadBasicAssets()
        {
            var collection = new GameObjectCollectionModel();
            var collider = new Collider
            {
                Name = "Collider",
                Sprite = MapEditorService.LoadBitmapFromPath(SpriteConstants.ColliderIconPath),
                HasEditorOverlay = true,
                EditorColor = Color.FromArgb(120, 255, 255, 255),
            };
            collection.GameObjects.Add(collider);
            Model.GameObjectCollections.Add(collection);
        }

        public RelayCommand AdjustTileSizeCommand { get => _adjustSpriteSize; set => _adjustSpriteSize = value; }
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
            AdjustMapSizeCommand = new RelayCommand(AdjustMapSize);
            AdjustTileSizeCommand = new RelayCommand(AdjustTileSize);
            RemoveSpriteFromSpriteCollectionCommand = new RemoveSpriteCommand(RemoveSprite);
        }

        private void NewMapDialog()
        {
            //TODO Invoke map changed delegate
            throw new NotImplementedException();
        }

        private void RemoveSprite(object model)
        {
            var spriteModel = (GameObject)model;
            if (spriteModel == null)
                throw new ArgumentException(nameof(GameObject));
           
            foreach (var collection in Model.GameObjectCollections)
            {
                var toDelete = collection.GameObjects.Where(sprite => sprite.Id == spriteModel.Id).FirstOrDefault();
                if(toDelete != null)
                {
                    collection.GameObjects.Remove(toDelete);
                    break;
                }
            }
        }

        public void SpriteFileDialog()
        {
            var spriteCollection = DialogService.GetSpriteCollection();
            if(spriteCollection == null) { return;}

            Model.GameObjectCollections.Add(spriteCollection);
        }

        public void ResetMap()
        {
            if(Model.EditorMap.Map != null)
            {
                //TODO ask user confirmation
            }
            Model.EditorMap.Map = MapEditorService.GetEmptyMap(Model.EditorMap);
            NewMapEvent?.Invoke();
        }

        public void OnMapSizeChanged()
        {
            var newMap = new MapObject[Model.EditorMap.MapWidth, Model.EditorMap.MapHeight];
            MapEditorService.CopyMap(Model.EditorMap.Map, newMap);
            Model.EditorMap.Map = newMap;
            ResizeMapEvent?.Invoke();
        }

        public void TileDeleted(int x, int y)
        {
            Model.EditorMap.Map[x, y] = new MapObject 
            { 
                MapRectangle = new System.Windows.Shapes.Rectangle 
                {
                    Height = Model.EditorMap.TileHeight, Width = Model.EditorMap.TileWidth 
                }
            };
        }

        public void AdjustMapSize()
        {
            ResetMap();
        }

        public void AdjustTileSize()
        {
            ResetMap();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Shapes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    public class MapEditorModel : ObservableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        #region Sprite panel
        public ObservableCollection<SpriteCollectionModel> _spriteCollection;
        public MapEditorModel()
        {
            _spriteCollection = new ObservableCollection<SpriteCollectionModel>();
            _spriteCollection.CollectionChanged += SpriteCollectionChanged;
        }

        public ObservableCollection<SpriteCollectionModel> SpriteCollections
        {
            get => _spriteCollection;
            set
            {
                _spriteCollection = value;
                SpriteCollectionChanged(this, null);
            }
        }

        private void SpriteCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_spriteCollection)));
        }
        #endregion

        #region Map editor 
        private Rectangle[,] _map;
        private int _mapHeight;
        private int _mapWidth;

        public Rectangle[,] Map
        {
            get => _map;
            set
            {
                _map = value;
                OnPropertyChanged(ref _map, value);
            }
        }

        public int MapHeight
        {
            get => _mapHeight;
            set
            {
                _mapHeight = value;
                OnPropertyChanged(ref _mapHeight, value);
            }
        }
        public int MapWidth
        {
            get => _mapWidth;
            set
            {
                _mapWidth = value;
                OnPropertyChanged(ref _mapWidth, value);
            }
        }
        #endregion
    }
}

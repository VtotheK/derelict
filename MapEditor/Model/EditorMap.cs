using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MapEditor.Model
{
    public delegate void MapSizeChangedEventHandler();
    public class EditorMap : ObservableObject
    {
        private MapObject[,] _map;
        private int _mapHeight;
        private int _mapWidth;
        private int _tileWidth;
        private int _tileHeight;

        public event MapSizeChangedEventHandler MapSizeChanged;

        public MapObject[,] Map
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
                MapSizeChanged?.Invoke();
            }
        }

        public int MapWidth
        {
            get => _mapWidth;
            set
            {
                _mapWidth = value;
                OnPropertyChanged(ref _mapWidth, value);
                MapSizeChanged?.Invoke();
            }
        }

        public int TileHeight
        {
            get => _tileHeight;
            set
            {
                _tileHeight = value;
                OnPropertyChanged(ref _tileHeight, value);
            }
        }

        public int TileWidth
        {
            get => _tileWidth;
            set
            {
                _tileWidth = value;
                OnPropertyChanged(ref _tileWidth, value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MapEditor.Model
{
    public class SpriteSplitterModel : ObservableObject
    {

        private string? _spriteWidth;
        private string? _spriteHeight;
        private string? _filepath;
        private int _sheetHeight;
        private int _sheetWidth;
        private BitmapImage _tileSet;

        public SpriteSplitterModel() { }
        public List<SpriteModel>  SpriteModels { get; set; }

        public string FilePath
        {
            get { return _filepath; }
            set
            {
                _filepath = value;
                TileSet = new BitmapImage(new Uri(FilePath, UriKind.Absolute));
                OnPropertyChanged(ref _filepath, value);
            }
        }

        public BitmapImage TileSet
        {
            get => _tileSet;
            set
            {
                _tileSet = value;
                OnPropertyChanged(ref _tileSet, value);
            }
        }

        public string SpriteWidth
        {
            get { return _spriteWidth; }
            set
            {
                _spriteWidth = value;
                OnPropertyChanged(ref _spriteWidth, value);
            }
        }
        public string SpriteHeight
        {
            get { return _spriteHeight; }
            set
            {
                _spriteHeight = value;
                OnPropertyChanged(ref _spriteHeight, value);
            }
        }
        public int SheetHeight
        {
            get
            {
                return _sheetHeight;
            }
            set
            {
                _sheetHeight = value;
                OnPropertyChanged(ref _sheetHeight, value);
            }
        }
        public int SheetWidth
        {
            get
            {
                return _sheetWidth;
            }
            set
            {
                _sheetHeight = value;
                OnPropertyChanged(ref _sheetWidth, value);
            }
        }
    }
}

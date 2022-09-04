using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MapEditor.Model
{
    public class SpriteSplitterModel : ObservableObject
    {

        private int? _spriteWidth;
        private int? _spriteHeight;
        private string? _filePath;
        private string? _fileName;
        private int _sheetHeight;
        private int _sheetWidth;
        private BitmapImage _UItileSet;
        private BitmapImage _originalTileSet;

        public SpriteSplitterModel() 
        {
            SpriteCollection = new GameObjectCollectionModel();
        }

        public GameObjectCollectionModel SpriteCollection { get; set; }
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                UITileSet = new BitmapImage(new Uri(FilePath, UriKind.Absolute));
                OriginalTileSet = new BitmapImage(new Uri(FilePath, UriKind.Absolute));
                FileName = Path.GetFileName(value);
                OnPropertyChanged(ref _filePath, value);
            }
        }

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged(ref _fileName, value);
            }
        }

        public BitmapImage OriginalTileSet
        {
            get => _originalTileSet;
            private set => _originalTileSet = value;
        }
        public BitmapImage UITileSet
        {
            get => _UItileSet;
            set
            {
                _UItileSet = value;
                SheetHeight = (int)UITileSet.Height;
                SheetWidth = (int)UITileSet.Width;
                OnPropertyChanged(ref _UItileSet, value);
            }
        }

        public int? SpriteWidth
        {
            get { return _spriteWidth; }
            set
            {
                _spriteWidth = value;
                OnPropertyChanged(ref _spriteWidth, value);
            }
        }
        public int? SpriteHeight
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

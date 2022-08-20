using System;
using System.Collections.Generic; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MapEditor.Extensions;

namespace MapEditor.Model
{
    public class SpriteModel : ObservableObject
    {
        private Bitmap _spriteImage;
        private string _name;
        private string _path;

        public BitmapSource SpriteSource 
        { 
            get => _spriteImage.ToBitmapImage(); 
        }

        public Bitmap SpriteImage
        {
            get => _spriteImage;
            set
            {
                _spriteImage = value;
                OnPropertyChanged(ref _spriteImage, value);
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(ref _name, value);
            }
        }
    }
}

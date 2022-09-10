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
    public abstract class GameObject : ObservableObject, IEquatable<GameObject>
    {
        //TODO: How to figure out position of the gameobject in the map?
        private Bitmap _sprite;
        private bool _hasEditorOverlay;
        private Color _editorColor;
        private string _name;
        private string _path;
        readonly Guid _id; 

        public Guid Id
        {
            get => _id;
        }

        public GameObject()
        {
            _id = Guid.NewGuid();
        }

        public BitmapSource SpriteSource 
        { 
            get => _sprite.ToBitmapImage(); 
        }

        public Bitmap Sprite
        {
            get => _sprite;
            set
            {
                _sprite = value;
                OnPropertyChanged(ref _sprite, value);
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

        public Color EditorColor
        {
            get => _editorColor;
            set
            {
                _editorColor = value;
                OnPropertyChanged(ref _editorColor, value);
            }
        }

        public bool HasEditorOverlay
        {
            get => _hasEditorOverlay;
            set
            {
                _hasEditorOverlay = value;
                OnPropertyChanged(ref _hasEditorOverlay, value);
            }
        }

        public override bool Equals(object other)
        {
            if (other.GetType() != typeof(GameObject)) return false;
            return other == null ? false : Id == ((GameObject)other).Id;
        }
        
        public bool Equals(GameObject? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }

    }
}

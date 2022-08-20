using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    public class MapEditorModel : INotifyPropertyChanged
    {
        public ObservableCollection<SpriteModel> _sprites;
        public MapEditorModel()
        {
            _sprites = new ObservableCollection<SpriteModel>();
            _sprites.CollectionChanged += SpriteCollectionChanged;
        }

        public ObservableCollection<SpriteModel> Sprites
        {
            get => _sprites;
            set
            {
                _sprites = value;
                SpriteCollectionChanged(this, null);
            }
        }

        private void SpriteCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_sprites)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

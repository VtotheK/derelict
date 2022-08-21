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
        public ObservableCollection<SpriteCollection> _spriteCollection;
        public MapEditorModel()
        {
            _spriteCollection = new ObservableCollection<SpriteCollection>();
            _spriteCollection.CollectionChanged += SpriteCollectionChanged;
        }

        public ObservableCollection<SpriteCollection> SpriteCollections
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

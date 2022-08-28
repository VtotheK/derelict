using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    public class SpriteCollectionModel : ObservableObject, INotifyPropertyChanged
    {
        public readonly string Id;
       
        private string _collectionName;
        private ObservableCollection<SpriteModel> _sprites;

        public SpriteCollectionModel()
        {
            Sprites = new ObservableCollection<SpriteModel>();
            Id = new Guid().ToString();
        }

        public ObservableCollection<SpriteModel> Sprites
        {
            get => _sprites;
            set
            {
                _sprites = value;
                OnPropertyChanged(ref _sprites, value);
            }
        }

        public string CollectionName
        {
            get => _collectionName;
            set
            {
                _collectionName = value;
                OnPropertyChanged(ref _collectionName, value);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    public class GameObjectCollectionModel : ObservableObject, INotifyPropertyChanged
    {
        public readonly string Id;
       
        private string _collectionName;
        private ObservableCollection<GameObject> _sprites;

        public GameObjectCollectionModel()
        {
            GameObjects = new ObservableCollection<GameObject>();
            Id = new Guid().ToString();
        }

        public ObservableCollection<GameObject> GameObjects
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

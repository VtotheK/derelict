﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    public class SpriteCollection : ObservableObject
    {
        public readonly string Id;
       
        private string _collectionName;
        private List<SpriteModel> _sprites;

        public SpriteCollection()
        {
            Sprites = new List<SpriteModel>();
            Id = new Guid().ToString();
        }

        public List<SpriteModel> Sprites
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using MapEditor.Model;

namespace MapEditor.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public List<Sprite> Sprites;

        public MainWindowViewModel()
        {
            Sprites = new List<Sprite>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

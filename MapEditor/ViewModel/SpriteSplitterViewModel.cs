using System;
using System.Collections.Generic;
using MapEditor.Model;
using MapEditor.ViewModel;

namespace MapEditor.ViewModel
{
    public class SpriteSplitterViewModel
    {
        public SpriteSplitterModel Model { get; private set; }
        public SpriteSplitterViewModel() 
        {
            Model = new SpriteSplitterModel();
        }

        public SpriteSplitterViewModel(SpriteSplitterModel model)
        {

            Model = model;
        }
    }
}

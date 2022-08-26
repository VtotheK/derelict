﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;
using MapEditor.Model;
using MapEditor.Service;

namespace MapEditor.ViewModel
{
    public class SpriteSplitterViewModel
    {
        public SpriteSplitterModel Model { get; private set; }
        private SpritesplitService splitService { get; set; }
        public SpriteSplitterViewModel() 
        {
            Model = new SpriteSplitterModel();
            splitService = new SpritesplitService();
        }

        public SpriteSplitterViewModel(SpriteSplitterModel model)
        {
            Model = model;
            splitService = new SpritesplitService();
        }

        public void CreatePreviewTilemap()
        {
            try
            {
                var previewImage = splitService.CreatePreviewTilemap(Model.OriginalTileSet, Model.SpriteWidth ?? 0, Model.SpriteHeight ?? 0);
                Model.UITileSet = previewImage;
            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }
        }

        public void ConfirmSpirteSplit()
        {
            if(Model.SpriteHeight <= 0)
            {
                MessageBox.Show("Sprite height have to over 0.", "Error", MessageBoxButton.OK);
                return;
            }
            if( Model.SpriteWidth <= 0)
            { 
                MessageBox.Show("Sprite width have to over 0.", "Error", MessageBoxButton.OK);
                return;

            }
            if(String.IsNullOrEmpty(Model.SpriteCollection.CollectionName))
            {
                MessageBox.Show("Sprite collection must have name.", "Error", MessageBoxButton.OK);
                return;
            }

            try
            {
                Model.SpriteCollection.Sprites = splitService.GetSprites(Model.OriginalTileSet, Model.SpriteWidth ?? 0, Model.SpriteHeight ?? 0);
            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }
        }
    }
}

﻿using MapEditor.Model;
using MapEditor.View;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace MapEditor.Service
{
    public static class DialogService
    {
        public static SpriteCollection GetSpriteCollection()
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "Jpeg files (.jpg)|*.jpg|PNG Files (.png)|*.png";

            string filePath;

            if(dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            else { return null; }

            var splitter = new SpriteSplitter(new SpriteSplitterModel
            {
                FilePath = filePath
            });

            splitter.ShowDialog();
            return splitter.viewModel.Model.SpriteCollection;
        }
    }
}

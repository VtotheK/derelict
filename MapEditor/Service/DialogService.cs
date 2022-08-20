using MapEditor.Model;
using MapEditor.View;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace MapEditor.Service
{
    public static class DialogService
    {
        public static List<SpriteModel> GetSprites()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (.jpg)|*.jpg|(.png)|*.png";
            dialog.DefaultExt = ".png";

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
            return splitter.viewModel.Model.SpriteModels;
        }
    }
}

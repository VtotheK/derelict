using MapEditor.Model;
using MapEditor.View;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace MapEditor.Service
{
    public static class DialogService
    {
        public static GameObjectCollectionModel GetSpriteCollection()
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "PNG Files (.png)|*.png|Jpeg files (.jpg)|*.jpg";

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
            if (splitter.viewModel.Model.SpriteCollection.GameObjects.Count == 0)
                return null;
            return splitter.viewModel.Model.SpriteCollection;
        }
    }
}

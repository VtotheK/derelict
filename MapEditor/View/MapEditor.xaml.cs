using MapEditor.Model;
using MapEditor.ViewModel;
using MapEditor.Extensions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapEditorViewModel ViewModel;
        BitmapSource currentTile;
        public MainWindow()
        {
            InitializeComponent();

            var model = new MapEditorModel
            {
                MapHeight = 50,
                MapWidth = 150,
                TileHeight = 16,
                TileWidth = 16,
            };

            ViewModel = new MapEditorViewModel(model);
            ViewModel.NewMapEvent += GenerateEmptyMap;
            ViewModel.ResizeMapEvent += ResizeCurrentMap;
            ViewModel.ResetMap();

            DataContext = ViewModel;
        }

        private void ResizeCurrentMap()
        {

        }

        private void GenerateEmptyMap()
        {
            TileCanvas.Children.Clear();
            int MapHeight = ViewModel.Model.MapHeight;
            int MapWidth = ViewModel.Model.MapWidth;
            int TileHeight = ViewModel.Model.TileWidth;
            int TileWidth = ViewModel.Model.TileHeight;

            for (int y = 0; y < MapHeight; ++y)
            {
                for(int x = 0; x < MapWidth; ++x)
                {

                    ViewModel.Model.Map[x, y] = new Rectangle
                    {
                        Width = 16,
                        Height = 16,
                        Fill = new SolidColorBrush(Color.FromArgb(0,0,0,0))
                    };
                    ViewModel.Model.Map[x,y].MouseEnter += Tilemap_MouseEnter;
                    ViewModel.Model.Map[x,y].MouseLeave += Tilemap_MouseLeave;
                    ViewModel.Model.Map[x,y].MouseLeftButtonDown += Tilemap_MouseLeftButtonDown;
                    Canvas.SetLeft(ViewModel.Model.Map[x,y], x * TileWidth);
                    Canvas.SetTop(ViewModel.Model.Map[x,y], y * TileHeight);
                    TileCanvas.Children.Add(ViewModel.Model.Map[x,y]);
                }
            }
            TileCanvas.Height = MapHeight * 16;
            TileCanvas.Width = MapWidth * 16;
        }

        private void Tilemap_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void Tilemap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { 
            if(currentTile == null) { return; }
            var rect = (Rectangle)sender;
            rect.Fill = new ImageBrush(currentTile);
        }

        private void Tilemap_MouseEnter(object sender, MouseEventArgs e)
        {
            var rect = (Rectangle)sender;
            rect.Fill = new SolidColorBrush(Color.FromArgb(20, 0, 0, 0));
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var textBox = (TextBox)sender;
                var prop = TextBox.TextProperty;
                var binding = BindingOperations.GetBindingExpression(textBox, prop);
                binding?.UpdateSource();
            }
        }

        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var tile = (System.Windows.Controls.Image)sender;
            var bi = tile.Source as BitmapImage;
            if(bi != null)
            {
                currentTile = bi;
            }
        }

        private void Tile_MouseEnter(object sender, MouseEventArgs e)
        {
            var tile = (Image)sender;
            tile.Opacity = 0.6;
        }

        private void Tile_MouseLeave(object sender, MouseEventArgs e)
        {
            var tile = (Image)sender;
            tile.Opacity = 1.0;
        }


        private void Tile_Selection(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as StackPanel).Children[1];
            Debug.WriteLine(item);
            Debug.WriteLine(item.GetType());
        }

        private void Tile_Selected(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Tile selected finally ffs");
        }

        private void FuckChanged(object sender, SelectionChangedEventArgs e)
        {
            var spriteModel = (sender as ListView)?.SelectedItem as SpriteModel;
            if(spriteModel != null)
            {
                currentTile = spriteModel.SpriteImage.ToBitmapImage();
            }
        }
    }
}

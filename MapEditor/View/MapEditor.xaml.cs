using MapEditor.Model;
using MapEditor.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MapEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapEditorViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MapEditorViewModel();
                
            var model = new MapEditorModel
            {
                MapHeight = 50,
                MapWidth = 150,
                TileHeight = 16,
                TileWidth = 16,
                MapSizeChanged = ViewModel.OnMapSizeChanged
            };

            ViewModel.NewMapEvent += GenerateEmptyMap;
            ViewModel.ResetMap();

            DataContext = ViewModel;
        }

        private void GenerateEmptyMap()
        {
            int MapHeight = ViewModel.Model.MapHeight;
            int MapWidth = ViewModel.Model.MapWidth;
            int TileHeight = ViewModel.Model.TileWidth;
            int TileWidth = ViewModel.Model.TileHeight;

            for (int y = 0; y < MapHeight; ++y)
            {
                for(int x = 0; x < MapWidth; ++x)
                {
                    var rand = new Random(DateTime.Now.GetHashCode());
                    var val = rand.Next(0, int.MaxValue);
                    var bytes = BitConverter.GetBytes(val);

                    ViewModel.Model.Map[x,y] = new Rectangle
                    {
                        Width = 16,
                        Height = 16,
                        Fill = new SolidColorBrush(Color.FromRgb(bytes[0], bytes[1], bytes[2]))
                    };
                    ViewModel.Model.Map[x,y].MouseEnter += Tilemap_MouseEnter;
                    Canvas.SetLeft(ViewModel.Model.Map[x,y], x * TileWidth);
                    Canvas.SetTop(ViewModel.Model.Map[x,y], y * TileHeight);
                    TileCanvas.Children.Add(ViewModel.Model.Map[x,y]);
                }
            }
            TileCanvas.Height = MapHeight * 16;
            TileCanvas.Width = MapWidth * 16;
        }

        private void Tilemap_MouseEnter(object sender, MouseEventArgs e)
        {
            //var rect = (Rectangle) sender;
            //throw new NotImplementedException();
        }
    }
}

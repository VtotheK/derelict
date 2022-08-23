using MapEditor.Model;
using MapEditor.ViewModel;
using System;
using System.Windows;
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
            ViewModel = new MapEditorViewModel(new MapEditorModel
            {
                MapHeight = 50,
                MapWidth = 50
            });

            ViewModel.ResetMap();
            DataContext = ViewModel;
            TempAddMapToCanvas();
            InitializeComponent();
        }

        private void TempAddMapToCanvas()
        {
            for(int i = 0; i < ViewModel.Model.Map.GetLength(0); ++i)
            {
                for(int j = 0; j < ViewModel.Model.Map.GetLength(1); ++j)
                {
                    ViewModel.Model.Map[i, j] = new Rectangle
                    {
                        Width = 50,
                        Height = 50,
                        Fill = new SolidColorBrush(Color.FromRgb(50,50,50))
                    };

                    ViewModel.Model.Map[i, j].MouseEnter += Tilemap_MouseEnter;
                    TileCanvas.Children.Add(ViewModel.Model.Map[i, j]);
                }
            }
        }

        private void Tilemap_MouseEnter(object sender, MouseEventArgs e)
        {
            //var rect = (Rectangle) sender;
            throw new NotImplementedException();
        }
    }
}

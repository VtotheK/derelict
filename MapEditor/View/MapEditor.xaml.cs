﻿using MapEditor.Model;
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

            var model = new MapEditorModel
            {
                EditorMap = new EditorMap
                {
                    MapHeight = 50,
                    MapWidth = 150,
                    TileHeight = 16,
                    TileWidth = 16,
                }
            };

            ViewModel = new MapEditorViewModel(model);
            ViewModel.NewMapEvent += GenerateEmptyMap;
            ViewModel.ResizeMapEvent += ResizeCurrentMap;
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.ResetMap();

        }

        private void ResizeCurrentMap()
        {

        }

        private void GenerateEmptyMap()
        {
            TileCanvas.Children.Clear();
            int MapHeight = ViewModel.Model.EditorMap.MapHeight;
            int MapWidth = ViewModel.Model.EditorMap.MapWidth;
            int TileHeight = ViewModel.Model.EditorMap.TileWidth;
            int TileWidth = ViewModel.Model.EditorMap.TileHeight;

            for (int y = 0; y < MapHeight; ++y)
            {
                for(int x = 0; x < MapWidth; ++x)
                {

                    var rect = new Rectangle
                    {
                        Width = 16,
                        Height = 16,
                        Fill = new SolidColorBrush(Color.FromArgb(0,0,0,0))
                    };
                    ViewModel.Model.EditorMap.Map[x, y] = rect;
                    ViewModel.Model.EditorMap.Map[x,y].MouseEnter += Tilemap_MouseEnter;
                    ViewModel.Model.EditorMap.Map[x,y].MouseLeave += Tilemap_MouseLeave;
                    ViewModel.Model.EditorMap.Map[x,y].MouseLeftButtonDown += Tilemap_MouseLeftButtonDown;
                    Canvas.SetLeft(ViewModel.Model.EditorMap.Map[x,y], x * TileWidth);
                    Canvas.SetTop(ViewModel.Model.EditorMap.Map[x,y], y * TileHeight);
                    TileCanvas.Children.Add(ViewModel.Model.EditorMap.Map[x,y]);
                    AddBorderToRect(rect, x * TileWidth, y * TileHeight);
                }
            }
            TileCanvas.Height = MapHeight * 16;
            TileCanvas.Width = MapWidth * 16;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">The border that will be drawn sizes</param>
        /// <param name="x">X coordinate of the upper left coordinate on the rect border</param>
        /// <param name="y">Y coordinate of the upper left coordinate on the rect border</param>
        private void AddBorderToRect(Rectangle rect, int x, int y)
        {
            int rectHeight = (int)rect.Height;
            int rectWidth = (int)rect.Width;
            (int xFrom, int yFrom, int xTo, int yTo) [] coords = new[]
            {
                (x, y, x + rectWidth, y),
                (x + rectWidth, y, x + rectWidth, y + rectHeight ),
                (x + rectWidth, y + rectHeight, x, y + rectHeight),
                (x, y + rectHeight, x, y),
            };

            foreach(var coord in coords)
            {
                var line = new Line()
                {
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 1,
                    X1 = coord.xFrom,
                    Y1 = coord.yFrom,
                    X2 = coord.xTo,
                    Y2 = coord.yTo,
                    SnapsToDevicePixels = true
                };

                TileCanvas.Children.Add(line);
            }
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

        private void TileSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var spriteModel = (sender as ListView)?.SelectedItem as SpriteModel;
            if(spriteModel != null)
            {
                currentTile = spriteModel.SpriteImage.ToBitmapImage();
            }
        }
    }
}

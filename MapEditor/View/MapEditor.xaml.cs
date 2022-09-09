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
using MapEditor.Service;

namespace MapEditor
{
    public partial class MainWindow : Window
    {
        MapEditorViewModel ViewModel;
        BitmapSource currentTile;
        MapObject[,] currentMap;
        GameObject selectedGameObject;
        public MainWindow()
        {

            var model = new MapEditorModel
            {
                EditorMap = new EditorMap
                {
                    MapHeight = 5,
                    MapWidth = 5,
                    TileHeight = 64,
                    TileWidth = 64,
                }
            };

            ViewModel = new MapEditorViewModel(model);
            ViewModel.NewMapEvent += GenerateMap;
            ViewModel.ResizeMapEvent += GenerateMap;
            DataContext = ViewModel;
            InitializeComponent();
            ViewModel.ResetMap();

        }

        private void GenerateMap()
        {
            TileCanvas.Children.Clear();
            int MapHeight = ViewModel.Model.EditorMap.MapHeight;
            int MapWidth = ViewModel.Model.EditorMap.MapWidth;
            int TileHeight = ViewModel.Model.EditorMap.TileHeight;
            int TileWidth = ViewModel.Model.EditorMap.TileWidth;
            TileCanvas.Height = MapHeight * TileHeight;
            TileCanvas.Width = MapWidth * TileWidth;

            EffectCanvas.Width = MapWidth * TileWidth;
            EffectCanvas.Height = MapHeight * TileHeight;

            for (int y = 0; y < MapHeight; ++y)
            {
                for(int x = 0; x < MapWidth; ++x)
                {
                    var mapRect = ViewModel.Model.EditorMap.Map[x, y].MapRectangle;

                    mapRect.MouseEnter += Tilemap_MouseEnter;
                    mapRect.MouseLeave += Tilemap_MouseLeave;
                    mapRect.MouseLeftButtonDown += Tilemap_MouseLeftButtonDown;
                    mapRect.MouseRightButtonDown += Tilemap_MouseRightButtonDown;
                    Canvas.SetLeft(mapRect, x * TileWidth);
                    Canvas.SetTop(mapRect, y * TileHeight);
                    TileCanvas.Children.Add(mapRect);

                    AddBorderToRect(mapRect, x * TileWidth, y * TileHeight);
                }
            }
            currentMap = ViewModel.Model.EditorMap.Map;
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
            //TODO Tile hightlighting
        }

        private void Tilemap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { 
            var rect = (Rectangle)sender;
            if(rect == null) { return; }

            int x = MapEditorService.GetXCoordinate(rect.Name);
            int y = MapEditorService.GetYCoordinate(rect.Name);

            if(selectedGameObject is Tile)
            {
                rect.Fill = new ImageBrush(currentTile);
            }
        }
        private void Tilemap_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rect = (Rectangle)sender;
            if(rect == null) { return; }
            var menu = FindResource("TileContextMenu") as ContextMenu;
            menu.PlacementTarget = rect;
            menu.IsOpen = true;
        }

        private void Tilemap_MouseEnter(object sender, MouseEventArgs e)
        {
            //TODO Tile hightlighting
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

        private void GameObjectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gameObject = (sender as ListView)?.SelectedItem as GameObject;
            if(gameObject is Tile)
            {
                selectedGameObject = gameObject;
                currentTile = gameObject.Sprite.ToBitmapImage();
            }
            else if(gameObject is SpawnPoint)
            {
                //TODO....
            }
        }

        private void TestyTileDelete(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var menu = item.Parent as ContextMenu;
            var rect = menu.PlacementTarget as Rectangle;
            if(rect != null)
            {
                rect.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                int x = MapEditorService.GetXCoordinate(rect.Name);
                int y = MapEditorService.GetYCoordinate(rect.Name);
                ViewModel.TileDeleted(x, y);
            }
        }
    }
}

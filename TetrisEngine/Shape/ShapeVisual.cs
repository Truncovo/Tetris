using System.Windows;
using System.Windows.Controls;
using TetrisEngine;
using Settings = TetrisEngine.Settings;

namespace TetrisEngine
{
    public class ShapeVisual: Grid
    {
        public Shape Shape { get; }  
        public ShapeVisual(Shape shape)
        {

            this.Margin = new Thickness(10);

            Shape = shape;

            //set rows
            for (int x = 0; x < Shape.Size.X; x++)
                this.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(Sprite.Size, GridUnitType.Pixel)
                });

            //set columns
            for (int y = 0; y < Shape.Size.Y; y++)
                this.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(Sprite.Size, GridUnitType.Pixel)
                });

            //Show sprites
            foreach (Coordinates coord in Shape)
            {
                Sprite sprite = new Sprite(Shape.Color);  
                Settings.PlaceInGridAndAdd(sprite,this,coord.X, coord.Y);
            }

        }
    }
}
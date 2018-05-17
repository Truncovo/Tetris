using System.Windows;
using System.Windows.Controls;

namespace TetrisEngine
{
    public class ShapeFE: Grid
    {
        public Shape Shape { get; }  
        public ShapeFE(Shape shape)
        {

            this.Margin = new Thickness(10);

            Shape = shape;

            //set rows
            for (int x = 0; x < 3; x++)
                this.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(Sprite.Size, GridUnitType.Pixel)
                });

            //set columns
            for (int y = 0; y < 4; y++)
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
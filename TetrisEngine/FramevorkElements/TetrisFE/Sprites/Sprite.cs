using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TetrisEngine
{
    public class Sprite:StackPanel
    {
        //private static BitmapImage _bitmaImage;
        public bool Locked { get; set; }
        public static double Size = 30;

        public Color Color { get; set; }

        public Sprite(Color color)
        {
            this.Height = Size;
            this.Width = Size;

            Color = color;
            Locked = false;

            //create rectangle - visible part of sprite
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Color);
            rect.Width = Size;
            rect.Height = Size;
            this.Children.Add(rect);
        }
    }
}
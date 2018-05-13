using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TetrisEngine
{
    public static class Settings
    {
        public static void PlaceInGrid(UIElement obj, int setRow, int setColumn, int setRowSpan = 1, int setColumnSpan = 1)
        {
            Grid.SetRow(obj, setRow);
            Grid.SetColumn(obj, setColumn);
            Grid.SetRowSpan(obj, setRowSpan);
            Grid.SetColumnSpan(obj, setColumnSpan);
        }

        public static void PlaceInGridAndAdd(UIElement obj, Grid grid, int setRow, int setColumn, int setRowSpan = 1, int setColumnSpan = 1)
        {
            grid.Children.Add(obj);
            PlaceInGrid(obj, setRow, setColumn, setRowSpan, setColumnSpan);
        }


    }
}
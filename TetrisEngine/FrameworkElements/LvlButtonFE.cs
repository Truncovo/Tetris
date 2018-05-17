using System.Windows;
using System.Windows.Controls;

namespace TetrisEngine
{
    public class LvlButtonFE : Button
    {
        public LvlItem LvlItem { get; }
        public LvlButtonFE(LvlItem item)
        {
            LvlItem = item;
            Content = LvlItem.Title;
            Height = 50;
            Width = 400;
            Margin = new Thickness(10);
        }
        
    }
}
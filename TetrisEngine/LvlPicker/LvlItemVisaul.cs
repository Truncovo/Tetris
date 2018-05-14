using System.Windows;
using System.Windows.Controls;

namespace TetrisEngine
{
    public class LvlItemVisaul : Button
    {
        public LvlItem LvlItem { get; }
        public LvlItemVisaul(LvlItem item)
        {
            LvlItem = item;
            Content = LvlItem.Title;
            Height = 50;
            Width = 400;
            Margin = new Thickness(10);
        }
        
    }
}
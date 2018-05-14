using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WindowsAndInput;

namespace TetrisEngine
{
    public class PickLvlControl : StackPanel
    {
        public PickLvlControl()
        {
        }

        public PickLvlControl AddLvlType(LvlItem item)
        {
            var lvlItem = new LvlItemVisaul(item);
            Children.Add(lvlItem);
            lvlItem.Click += OnLevelSelected;
            return this;
        }

        private void OnLevelSelected(object sender, RoutedEventArgs e)
        {
            LvlItemVisaul button = sender as LvlItemVisaul;
            GeneralWindow.Get.WindowSetting = button.LvlItem.WindowSetting;
        }
    }
}
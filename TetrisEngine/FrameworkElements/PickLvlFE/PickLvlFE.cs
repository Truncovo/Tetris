using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WindowsAndInput;

namespace TetrisEngine
{
    public class PickLvlFE : StackPanel
    {
        public PickLvlFE()
        {
        }

        public PickLvlFE AddLvlType(LvlItem item)
        {
            var lvlItem = new LvlButtonFE(item);
            Children.Add(lvlItem);
            lvlItem.Click += OnLevelSelected;
            return this;
        }

        private void OnLevelSelected(object sender, RoutedEventArgs e)
        {
            LvlButtonFE button = sender as LvlButtonFE;
            GeneralWindow.Get.WindowSetting = button.LvlItem.WindowSetting;
        }
    }
}
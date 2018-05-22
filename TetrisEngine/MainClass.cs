using System;
using WindowsAndInput;

namespace TetrisEngine
{
    class MainClass
    {
        [STAThread]
        public static void Main()
        {
            GeneralWindow.Get.WindowSetting = new PickLvl();
            GeneralWindow.Get.Run();
        }
    }


}
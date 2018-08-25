using System;
using WindowsAndInput;
using TetrisEngine.AzureDatabase;

namespace TetrisEngine
{
    class MainClass
    {
        [STAThread]
        public static void Main()
        {
            //var context = new TruncovoEntities1();
            //var highScore = new HighScore
            //{
            //    LogID = 1,
            //    PlayerName = "Trunec",
            //    Score = 25,
            //    timeStamp = DateTime.Now
            //};
            //context.HighScores.Add(highScore);
            //context.SaveChanges();

            GeneralWindow.Get.WindowSetting = new PickLvl();
            GeneralWindow.Get.Run();
        }
    }
}
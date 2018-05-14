using System.Windows.Input;
using WindowsAndInput;

namespace TetrisEngine
{
    public class PickLvl : IWindowSetting
    {
        public void SetWindow(GeneralWindow window)
        {
            var pickLvl = new PickLvlControl();
            window.Content = pickLvl;
            pickLvl.AddLvlType(new LvlItem(new SinglePlayerNoSpeeding(), "Single Player"));
            pickLvl.AddLvlType(new LvlItem(new MultiPlayer(), "Multiplayer"));

        }

        public void ProcesKeyDown(KeyEventArgs e)
        {

        }

        public void ProcesMouseDown(MouseButtonEventArgs e)
        {
        }
    }
}
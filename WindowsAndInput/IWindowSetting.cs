using System.Windows.Input;

namespace WindowsAndInput
{
    public interface IWindowSetting
    {
        void SetWindow(GeneralWindow window);
        void ProcesKeyDown(KeyEventArgs e);
        void ProcesMouseDown(MouseButtonEventArgs e);
    }
}
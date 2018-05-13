using System.Windows.Input;

namespace TetrisEngine
{
    public interface IKeyLayout
    {
        void ProcesKey(TetrisGrid tetrisGrid,KeyEventArgs e);
    }
}
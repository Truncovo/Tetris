using System.Windows.Input;

namespace TetrisEngine
{
    public interface IKeyLayout
    {
        void ProcesKey(TetrisFE tetrisGrid,KeyEventArgs e);
    }
}
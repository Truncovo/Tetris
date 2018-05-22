using System.Windows.Input;

namespace TetrisEngine
{
    public interface IKeyLayout
    {
        void ProcessKey(ITetrisFE tetrisFE,KeyEventArgs e);
    }
}
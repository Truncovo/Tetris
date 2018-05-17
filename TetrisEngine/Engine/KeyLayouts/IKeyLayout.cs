using System.Windows.Input;

namespace TetrisEngine
{
    public interface IKeyLayout
    {
        void ProcessKey(ITetrisControl tetrisGrid,KeyEventArgs e);
    }
}
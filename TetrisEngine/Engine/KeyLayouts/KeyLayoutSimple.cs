using System;
using System.Linq;
using System.Windows.Input;

namespace TetrisEngine
{
    public class KeyLayoutSimple : IKeyLayout
    {
        private Key[] _controlArray;
        public Key[] ControlArray
        {
            get => _controlArray;
            set
            {
                if (value.Length != 6)
                    throw new ArgumentException();
                _controlArray = value;
            }
        } 

        public KeyLayoutSimple(Key[] controlArray)
        {
            if (controlArray.Length != 6)
                throw new ArgumentException();
            ControlArray = controlArray;
        }

        public void SetKey(Key key, Commands comand)
        {
            var tmp = _controlArray.Clone();
            ControlArray[(int)comand] = key;
            if (ControlArray.Distinct().Count() == ControlArray.Length)
                return;
            ControlArray = (Key[])tmp;
            throw new Exception();
        }

      

        public void ProcessKey(ITetrisFE tetrisFE, KeyEventArgs e)
        {
            if (!_controlArray.Contains(e.Key))
                return;

            switch ((Commands)Array.IndexOf(_controlArray, e.Key))
            {
                case Commands.MoveLeft:
                    tetrisFE.MoveLeft();
                    break;
                case Commands.MoveRight:
                    tetrisFE.MoveRight();
                    break;
                case Commands.MoveDown:
                    tetrisFE.MoveDown();
                    break;
                case Commands.RotateLeft:
                    tetrisFE.RotateLeft();
                    break;
                case Commands.RotateRight:
                    tetrisFE.RotateRight();
                    break;
                case Commands.DropToBot:
                    tetrisFE.DropToBot();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            e.Handled = true;
        }

        public enum Commands
        {
            MoveLeft = 0,
            MoveRight = 1,
            MoveDown = 2,
            RotateLeft = 3,
            RotateRight = 4,
            DropToBot = 5
        }

    }
}
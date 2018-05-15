using System.Windows.Input;

namespace TetrisEngine
{
    public static class KeyLayouts
    {
        public static IKeyLayout SinglePlayerLayout=> new KeyLayoutSimple
        {
            DropBot = Key.Space,
            MoveDown = Key.Down,
            MoveLeft = Key.Left,
            MoveRight = Key.Right,
            RotateLeft = Key.A,
            RotateRight = Key.D
        };
        public static IKeyLayout NumPadArowsLayout=> new KeyLayoutSimple
        {
            DropBot = Key.NumPad0,
            MoveDown = Key.Down,
            MoveLeft = Key.Left,
            MoveRight = Key.Right,
            RotateLeft = Key.NumPad7,
            RotateRight = Key.NumPad9
        };
        public static IKeyLayout LeftSideOfKeyboardLayout => new KeyLayoutSimple
        {
            DropBot = Key.Space,
            MoveDown = Key.S,
            MoveLeft = Key.A,
            MoveRight = Key.D,
            RotateLeft = Key.C,
            RotateRight = Key.B
        };

    }
}
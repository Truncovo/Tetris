using System.Windows.Input;

namespace TetrisEngine
{
    public static class KeyLayouts
    {
        public static IKeyLayout SinglePlayerLayout=> new KeyLayoutSimple
            (
            new Key[6]
            {
                Key.Left,
                Key.Right,
                Key.Down,
                Key.A,
                Key.D,
                Key.Space
            }
            );
        public static IKeyLayout NumPadArowsLayout=> new KeyLayoutSimple(new Key[6]
        {
            Key.Left,
            Key.Right,
            Key.Down,
            Key.NumPad7,
            Key.NumPad9,
            Key.NumPad0,

        });
        public static IKeyLayout LeftSideOfKeyboardLayout => new KeyLayoutSimple(new Key[6]
        {
            Key.A,
            Key.D,
            Key.S,
            Key.C,
            Key.B,
            Key.Space,
        });

    }
}
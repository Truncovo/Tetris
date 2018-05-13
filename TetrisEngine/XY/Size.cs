namespace TetrisEngine
{
    public class Size :XY
    {
        public Size(int x, int y) : base(x, y)
        {
        }

        public Size(Size size) : base(size.X,size.Y)
        {
        }
    }
}
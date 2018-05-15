using System;

namespace TetrisEngine
{
    public class Coordinates: XY
    {
        public Coordinates(int x, int y) : base(x, y)
        {
        }

        public Coordinates(Size size) : base(size.X,size.Y )
        {
        }

        private static Coordinates CalculateAbsolutCoordinates(Coordinates topLeft, Coordinates relativeInShape)
        {
            return new Coordinates(relativeInShape.X + topLeft.X, relativeInShape.Y + topLeft.Y);
        }

        public static Coordinates operator +(Coordinates c1, Coordinates c2)
        {
            return new Coordinates(c1.X + c2.X,c1.Y + c2.Y);
        }
    }
}
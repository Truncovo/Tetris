using System;

namespace TetrisEngine
{
    public class XY: IComparable <XY>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public XY(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ("["+X + ","+Y +"]");
        }

        public override bool Equals(object obj)
        {
            XY second = obj as XY;
            if (second == null)
                return false;
            if (X != second.X)
                return false;
            if (Y != second.Y)
                return false;
            return true;
        }

        public int CompareTo(XY other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var xComparison = X.CompareTo(other.X);
            if (xComparison != 0) return xComparison;
            return Y.CompareTo(other.Y);
        }
    }
}
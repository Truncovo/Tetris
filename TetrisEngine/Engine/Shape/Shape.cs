using System;
using System.Collections;
using System.Windows.Media;
using TetrisEngine;

namespace TetrisEngine
{
    public class Shape : IEnumerable, ICloneable
    {
        public Color Color { get; set; }
        public bool[,] Map { get; }

        public int Size { get; }

        //create empty shape
        public Shape(int size)
        {
            if (size > 4 || size < 1)
                throw new ArgumentOutOfRangeException("size of shape bigger than 4"); //TODO manage exceptions
            Map = new bool[size,size];
            Size = size;
        }

        //return Shape copy rotated 90° in direction of parametter rotation
        public Shape GetRotatedCopy(Rotation rotation)
        {
            switch (rotation)
            {
                case Rotation.Left:
                    return GetLeftRotatedCopy();
                case Rotation.Right:
                    return GetRightRotatedCopy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(rotation) + " MSG: ARE WE GOING 3D?", rotation, null);
            }

        }
        
        //user can iterate in all true coordinates in Map
        public IEnumerator GetEnumerator()
        {
            return new ShapeEnumeretaor(this);
        }

        public object Clone()
        {
            var res = new Shape(Size);

            res.Color = Color;

            for (int x = 0; x < Size; x++)
            for (int y = 0; y < Size; y++)
            {
                res.Map[x, y] = this.Map[x, y];
            }
            return res;
        }

        //=======================================================================================
        //private part
        private Shape GetLeftRotatedCopy()
        {
            var res = new Shape(Size);
            res.Color = Color;
            for (int x = 0; x < Size; x++)
            for (int y = 0; y < Size; y++)
            {
                res.Map[x, y] = this.Map[y, Size - 1 - x];
            }
            return res;
        }
        private Shape GetRightRotatedCopy()
        {
            var res = new Shape(Size);
            res.Color = Color;

            for (int x = 0; x < Size; x++)
            for (int y = 0; y < Size; y++)
            {
                res.Map[x, y] = this.Map[Size - y - 1, x];
            }
            return res;
        }

       

        public override bool Equals(object obj)
        {
            var second = obj as Shape;
            if (second == null)
                return false;
            if (Color.Equals(second.Color) && Map.Length == second.Map.Length)
            { 
                for (var x = 0; x < Size; x++)
                for (var y = 0; y < Size; y++)
                    if (Map[x, y] != second.Map[x, y])
                            return false;
                return true;
            }
            return false;
        }
    }
}
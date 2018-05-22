using System;
using System.Collections;
using TetrisEngine;

namespace TetrisEngine
{
    public class ShapeEnumeretaor : IEnumerator
    {
        private readonly Shape _shape;
        private int _x;
        private int _y;

        public ShapeEnumeretaor(Shape shape)
        {
            Reset();
            _shape = shape;
        }

        public bool MoveNext()
        {
            //find next true coordinates
            try
            {
                do
                {
                    if (++_x >= _shape.Size)
                    {
                        ++_y;
                        _x = 0;
                    }
                } while (!_shape.Map[_y, _x]);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _x = -1;
            _y = 0;
        }

        public Coordinates Current => new Coordinates(_y,_x);

        object IEnumerator.Current => Current;
    }
}
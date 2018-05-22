
using System;

namespace TetrisEngine
{

    //NotNeeded class, can be replaced with ShapesGenerator(shape)
    public class OneTypeGenerator : IShapeGenerator
    {
        private readonly Shape _shape;
        public OneTypeGenerator(Shape shape)
        {
            _shape = shape;
        }
        public Shape GetShape()
        {
            return _shape.Clone() as Shape;
        }

        public int RandomSeed
        {
            set => throw new NotImplementedException();
        }
    }
}

namespace TetrisEngine
{
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
    }
}
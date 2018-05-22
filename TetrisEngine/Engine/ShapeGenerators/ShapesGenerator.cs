using System;
using System.Collections.Generic;
using System.Reflection;

namespace TetrisEngine
{
    //randomly generating allshapes from class Shapes
    public class ShapesGenerator : IShapeGenerator
    {
        private Random _random;
        private readonly List<Shape> _shapes = new List<Shape>();

        public int RandomSeed
        {
            set => _random = new Random(value);
        }

        public ShapesGenerator(params Shape[] shapes) 
        {
            _random = new Random();

            foreach (var shape in shapes)
                _shapes.Add(shape);
        }

        public ShapesGenerator()
        {
            _random = new Random();
            FillWithAllShapes();
        }

        public virtual Shape GetShape()
        {
            //generating random shape  
            int randomInt = _random.Next(0, _shapes.Count);
            return (Shape) _shapes[randomInt].Clone();
        }

        private void FillWithAllShapes()
        {
            _shapes.Clear();

            Type type = typeof(Shapes);
            var allMethods = type.GetMethods();
            foreach (MethodInfo method in allMethods)
            {
                if (method.IsStatic && method.ReturnType == typeof(Shape))
                {
                    var shape = (Shape) method.Invoke(null, null);
                    _shapes.Add(shape);
                }
            }
        }
    }
}
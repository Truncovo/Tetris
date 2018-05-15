using System;
using System.Collections.Generic;
using System.Reflection;

namespace TetrisEngine
{
    //randomly generating allshapes from class Shapes
    public class AllShapesGenerator : IShapeGenerator
    {
        private readonly Random _random = new Random();
        private readonly List<MethodInfo> _shapes = new List<MethodInfo>();

        public AllShapesGenerator()
        {
            //store all methodInfo of static mehods returning shape
            Type type = typeof(Shapes);
            var allMethods = type.GetMethods();
            foreach (MethodInfo method in allMethods)
            {
                if (method.IsStatic && method.ReturnType == typeof(Shape))
                    _shapes.Add(method);
            }
        }

        public virtual Shape GetShape()
        {
            //generating random shape  
            int randomInt = _random.Next(0, _shapes.Count);
            return (Shape)_shapes[randomInt].Invoke(null, null);
        }
    }
}
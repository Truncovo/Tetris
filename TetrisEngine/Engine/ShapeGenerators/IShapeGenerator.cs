using System.CodeDom;

namespace TetrisEngine
{

    //interface witch is needed in constructor of TetrisGrid
    public interface IShapeGenerator
    {
        Shape GetShape();
    }

    
    public delegate void ShapeGeneratorWithPredictionEventHandler(object source);

    //interface witch expand shape generator - adding prediction of shapes
}
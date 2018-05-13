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
    public interface IShapeGeneratorWithPrediction : IShapeGenerator
    {

        event ShapeGeneratorWithPredictionEventHandler QueueChanged;
        event ShapeGeneratorWithPredictionEventHandler ShapePoped;

        int PredictCount { get;  }
        void ResetQueue();
        Shape GetPreditction(int i);
        Shape[] GetAllPredictions();
    }
}
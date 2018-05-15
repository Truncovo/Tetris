namespace TetrisEngine
{
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
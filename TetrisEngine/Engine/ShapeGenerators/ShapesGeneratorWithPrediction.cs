using System.Collections.Generic;

namespace TetrisEngine
{
    public class ShapesGeneratorWithPrediction : ShapesGenerator, IShapeGeneratorWithPrediction
    {
        public int PredictCount { get; }
        private readonly Queue<Shape> _shapeQueue;
        public ShapesGeneratorWithPrediction(int predictCount,params Shape[] shapes) : base(shapes) 
        {
            PredictCount = predictCount;
            _shapeQueue = new Queue<Shape>();
            ResetQueue();
        }

        public ShapesGeneratorWithPrediction(int predictCount) : base()
        {
            PredictCount = predictCount;
            _shapeQueue = new Queue<Shape>();
            ResetQueue();
        }

        public void ResetQueue()
        {
            _shapeQueue.Clear();
            for (int i = 0; i < PredictCount; i++)
            {
                _shapeQueue.Enqueue(base.GetShape());
            }
            OnQueueChanged(this);
        }
        public Shape GetPreditction(int i)
        {
            return _shapeQueue.ToArray()[i];

        }

        public Shape[] GetAllPredictions()
        {
            return _shapeQueue.ToArray();
        }

        public override Shape GetShape()
        {
            _shapeQueue.Enqueue(base.GetShape());
            var res = _shapeQueue.Dequeue();
            OnShapePoped(this);
            OnQueueChanged(this);
            return res;
        }

        public event ShapeGeneratorWithPredictionEventHandler QueueChanged;
        public event ShapeGeneratorWithPredictionEventHandler ShapePoped;

        protected virtual void OnQueueChanged(object source)
        {
            QueueChanged?.Invoke(source);
        }

        protected virtual void OnShapePoped(object source)
        {
            ShapePoped?.Invoke(source);
        }
    }
}
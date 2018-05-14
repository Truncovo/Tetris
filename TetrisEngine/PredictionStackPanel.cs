using System.Windows.Controls;

namespace TetrisEngine
{
    public class PredictionStackPanel : StackPanel
    {
        private IShapeGeneratorWithPrediction _shapeGenerator;

        //public bool IsPredicting { get; private set; }

        public PredictionStackPanel(TetrisGrid positionGrid)
        {
            SetShapeGenerator(positionGrid);
            positionGrid.ShapeGeneratorChanged += OnShapeGeneratorChanged;
            OnShapeGeneratorPoped(null);
        }

        public PredictionStackPanel(IShapeGeneratorWithPrediction sapeGenerator)
        {
            _shapeGenerator = sapeGenerator;
            _shapeGenerator.ShapePoped += OnShapeGeneratorPoped;
            OnShapeGeneratorPoped(null);
        }

        //if shape generator changed - we need to know
        private void OnShapeGeneratorChanged(object source)
        {
            SetShapeGenerator(source as TetrisGrid);
        }

        //if Tetris grid has generator with prediction - save ptr to property
        private void SetShapeGenerator(TetrisGrid positionGrid)
        {
            //unsubsribe from event
            if(_shapeGenerator != null)
                _shapeGenerator.ShapePoped -= OnShapeGeneratorPoped;

            //get predicting shape generator 
            _shapeGenerator = positionGrid.ShapeGenerator as IShapeGeneratorWithPrediction;

          

            //subrscibe event when shape is generated
            _shapeGenerator.ShapePoped += OnShapeGeneratorPoped;

        }

        private void OnShapeGeneratorPoped(object source)
        {
            this.Children.Clear();
            foreach (Shape shape in _shapeGenerator.GetAllPredictions())
                this.Children.Add(new ShapeVisual(shape));
        }
    }
}
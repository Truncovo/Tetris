using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TetrisEngine
{
    public partial class TetrisFE : Grid
    {
        private Sprite[,] _spiteArray;
        public Size Size { get; }

        //propertyes for handling background colors
        private Brush _bgPlayingBrush;
        public Brush BgPlayingBrush
        {
            get => _bgPlayingBrush;
            set
            {
                _bgPlayingBrush = value;
                if (Playing)
                    Background = _bgPlayingBrush;
            }
        }

        private Brush _gameOverBgBrush;
        public Brush GameOverBgBrush
        {
            get => _gameOverBgBrush;
            set
            {
                _gameOverBgBrush = value;
                if (!Playing)
                    Background = _gameOverBgBrush;
            }
        }


        private Shape _activeShape;
        private Coordinates _acticeShapeCoordinates;

        private IShapeGenerator _shapeGenerator;
        public IShapeGenerator ShapeGenerator
        {
            get => _shapeGenerator;
            set
            {
                _shapeGenerator = value;
                OnShapeGeneratorChanged();
            }
        }

        //konstruktor 
        public TetrisFE(Size size, IShapeGenerator shapeGenerator)
        {
            Size = size;
            ShapeGenerator = shapeGenerator;
            _bgPlayingBrush = Brushes.Black;
            _gameOverBgBrush = Brushes.DarkRed;

            this.TimerCtor();
          
            //add rows and columns to grid
            for (int i = 0; i < size.Y; i++)
                this.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(Sprite.Size, GridUnitType.Pixel)});

            for (int i = 0; i < size.X; i++)
                this.RowDefinitions.Add(new RowDefinition {Height = new GridLength(Sprite.Size, GridUnitType.Pixel)});


            this.ShowGridLines = true;
            this.Background = _bgPlayingBrush;
            _spiteArray = new Sprite[size.X, size.Y];
        }

        

        private void NextShape()
        {

            //if there is some shape, place single sprites into spriteArray
            if (_activeShape != null)
                SplitActiveShape();

            //spawn new shape, if shape can not be spawn, invoke game over
            try
            {
                SpawnShape(ShapeGenerator.GetShape());
            }
            catch (CantFitInException)
            {
                OnGameOver();
            }
        }
    }
}
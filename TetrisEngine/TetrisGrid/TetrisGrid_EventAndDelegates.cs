using System;
using System.Windows.Media;

namespace TetrisEngine
{
    public partial class TetrisGrid
    {
        public delegate void PositionGridEventHandler(object source);

        public event PositionGridEventHandler NewShapeGenerated;
        public event PositionGridEventHandler GameOver;
        public event PositionGridEventHandler LineCleared;
        public event PositionGridEventHandler ShapeTickDown;
        public event PositionGridEventHandler CantRotate;
        public event PositionGridEventHandler CantMoveLeftOrRight;
        public event PositionGridEventHandler ShapeLanded;
        public event PositionGridEventHandler ShapeGeneratorChanged;
        public event PositionGridEventHandler NewGameStarted;


        protected virtual void OnNewShapeGenerated()
        {
            Console.WriteLine("Shape generated");
            NewShapeGenerated?.Invoke(this);
        }

        protected virtual void OnGameOver()
        {
            Console.WriteLine("Game Over");
            Pause();
            this.Background = _gameOverBgBrush;
            GameOver?.Invoke(this);
        }

        protected virtual void OnLineCleared()
        {
            Console.WriteLine("Line cleared");
            LineCleared?.Invoke(this);
        }

        protected virtual void OnShapeTickDown()
        {
            Console.WriteLine("Shape moved down");
            ShapeTickDown?.Invoke(this);
        }

        protected virtual void OnCantRotate()
        {
            Console.WriteLine("Cant rotate");
            CantRotate?.Invoke(this);
        }

        protected virtual void OnCantMoveLeftOrRight()
        {
            Console.WriteLine("Cant move left or right");
            CantMoveLeftOrRight?.Invoke(this);
        }

        protected virtual void OnShapeLanded()
        {
            Console.WriteLine("Shape landed");
            SplitActiveShape();
            CheckAndDeleteAllLines();
            ShapeLanded?.Invoke(this);  
        }

        protected virtual void OnShapeGeneratorChanged()
        {
            ShapeGeneratorChanged?.Invoke(this);
        }

        protected virtual void OnNewGameStarted(object source)
        {
            NewGameStarted?.Invoke(source);
        }
    }
}
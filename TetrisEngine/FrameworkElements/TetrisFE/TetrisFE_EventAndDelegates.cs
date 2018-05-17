using System;
using System.Windows.Media;

namespace TetrisEngine
{
    public partial class TetrisFE
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
            NewShapeGenerated?.Invoke(this);
        }

        protected virtual void OnGameOver()
        {
            Pause();
            this.Background = _gameOverBgBrush;
            GameOver?.Invoke(this);
        }

        protected virtual void OnLineCleared()
        {
            LineCleared?.Invoke(this);
        }

        protected virtual void OnShapeTickDown()
        {
            ShapeTickDown?.Invoke(this);
        }

        protected virtual void OnCantRotate()
        {
            CantRotate?.Invoke(this);
        }

        protected virtual void OnCantMoveLeftOrRight()
        {
            CantMoveLeftOrRight?.Invoke(this);
        }

        protected virtual void OnShapeLanded()
        {
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
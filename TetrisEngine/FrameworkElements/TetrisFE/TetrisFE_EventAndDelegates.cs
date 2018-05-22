using System;
using System.Windows.Media;

namespace TetrisEngine
{
    public delegate void TetrisFeEventHandler(object source);

    public partial class TetrisFE: ITetrisFE
    {

        public event TetrisFeEventHandler NewShapeGenerated;
        public event TetrisFeEventHandler GameOver;
        public event TetrisFeEventHandler LineCleared;
        public event TetrisFeEventHandler ShapeTickDown;
        public event TetrisFeEventHandler CantRotate;
        public event TetrisFeEventHandler CantMoveLeftOrRight;
        public event TetrisFeEventHandler ShapeLanded;
        public event TetrisFeEventHandler ShapeGeneratorChanged;
        public event TetrisFeEventHandler NewGameStarted;


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
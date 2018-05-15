using System;

namespace TetrisEngine
{
    public class ScoreCounter
    {
        private int _score;

        public int Score
        {
            get => _score;
            private set
            {
                _score = value;
                OnScoreChanged(this);
            }
        }

        
        public ScoreCounter(TetrisFE positionGrid)
        {
            //subscibe events witch will afect score
            positionGrid.LineCleared += OnLineCleared;
            positionGrid.ShapeLanded += OnShapeLanded;
            //subrcibe event to invoke own event when game ended
            positionGrid.GameOver += OnGameOver;
            //subscibe event when score counter need to be reseted
            positionGrid.NewGameStarted += OnNewGameStarted;
        }

        private void OnGameOver(object source)
        {
            OnFinalScore(this);
        }

        private void OnNewGameStarted(object source)
        {
            Score = 0;
        }

        private void OnShapeLanded(object source)
        {
            Score += 3;
        }

        private void OnLineCleared(object source)
        {
            Score += (source as TetrisFE).Size.Y * 10;
        }


        public delegate void ScoreCounterEventHandler(object source);

        public event ScoreCounterEventHandler ScoreChanged;
        public event ScoreCounterEventHandler FinalScore;

        protected virtual void OnFinalScore(object source)
        {
            FinalScore?.Invoke(source);
        }

        protected virtual void OnScoreChanged(object source)
        {
            ScoreChanged?.Invoke(source);
        }
    }
}
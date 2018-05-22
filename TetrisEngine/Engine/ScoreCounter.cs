using System;

namespace TetrisEngine
{
    public class ScoreCounter
    {
        private int _score;
        private ITetrisFE _tetrisFE;
        public int ScoreUpOnShapeLanded { get; set; } = 3;
        public int ScoreUpOnSpriteCleared { get; set; } = 10;

        public int Score    
        {
            get => _score;
            private set
            {
                _score = value;
                OnScoreChanged(this);
            }
        }

        
        public ScoreCounter(ITetrisFE tetrisFE)
        {
            _tetrisFE = tetrisFE;

            //subscibe events witch will afect score
            tetrisFE.LineCleared += OnLineCleared;
            tetrisFE.ShapeLanded += OnShapeLanded;
            //subrcibe event to invoke own event when game ended
            tetrisFE.GameOver += OnGameOver;
            //subscibe event when score counter need to be reseted
            tetrisFE.NewGameStarted += OnNewGameStarted;
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
            Score += ScoreUpOnShapeLanded;
        }

        private void OnLineCleared(object source)
        {

            Score += _tetrisFE.Size.Y * ScoreUpOnSpriteCleared;
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
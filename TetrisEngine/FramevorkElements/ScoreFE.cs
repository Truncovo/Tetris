using System.Windows;
using System.Windows.Controls;

namespace TetrisEngine
{
    public class ScoreFE: TextBlock
    {

        public ScoreFE(ScoreCounter scoreCounter)
        {
            this.Margin = new Thickness(20);

            //Text block with actual score 
            Margin = new Thickness(10);
            TextUpdate(scoreCounter);
            FontSize = 25;


            //subscribing event - we need to know when score is changed
            scoreCounter.ScoreChanged += OnScoreChanged;

            //subscribing event - to know when game over happened
            scoreCounter.FinalScore += OnFinalScore;
        }

        private void TextUpdate(object source)
        {
            var scoreCounter = source as ScoreCounter;
            if (scoreCounter == null) return;
            Text = (scoreCounter).Score.ToString();
        }
        private void OnFinalScore(object source)
        {
        }

        private void OnScoreChanged(object source)
        {
            TextUpdate(source);
        }
    }
}
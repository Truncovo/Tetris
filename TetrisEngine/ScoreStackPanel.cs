using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TetrisEngine
{
    public class ScoreShower : TextBlock
    {

        public ScoreShower(ScoreCounter scoreCounter)
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

    public class ScoreStackPanel : StackPanel
    {
        private readonly TextBlock _actualScoreText;
        private readonly SortedList<int , ScoreLine> _sortedScoreList;

        public ScoreStackPanel(ScoreCounter scoreCounter)
        {
            this.Margin = new Thickness(20);

            _sortedScoreList = new SortedList<int, ScoreLine>();

            //Text block with actual score 
            _actualScoreText = new TextBlock();
            _actualScoreText.Margin = new Thickness(10);
            _actualScoreText.Text = "Score: " + scoreCounter.Score;
            _actualScoreText.FontSize = 25;
            this.Children.Add(_actualScoreText);


            //subscribing event - we need to know when score is changed
            scoreCounter.ScoreChanged += OnScoreChanged;

            //subscribing event - to know when game over happened
            scoreCounter.FinalScore += OnFinalScore;
        }

        private void OnFinalScore(object source)
        {
            //get nick of player from dialog window
            NickWindow nickWindow = new NickWindow();
            nickWindow.ShowDialog();

            //get final score 
            int score = (source as ScoreCounter).Score;

            //insert new line with score hisory
            ScoreLine scoreLine = new ScoreLine(score, nickWindow.Nick);
            _sortedScoreList.Add(score,scoreLine);

            //show sorted score history
            Children.Clear();
            Children.Add(_actualScoreText);
            var scoreList = _sortedScoreList.Values;
            for (int i = scoreList.Count-1; i >= 0 ; i--)
            {
                Children.Add(scoreList[i]);

            }
        }

        private void OnScoreChanged(object source)
        {
            _actualScoreText.Text = "Score: " + (source as ScoreCounter).Score;
        }

        //class representing one line in score history
        private class ScoreLine : Grid , IComparable<ScoreLine>
        {
            private int Score { get; }
            private string Nick { get;}

            public ScoreLine(int score, string nick)
            {
                
                //add colums to grid
                this.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(60,GridUnitType.Pixel)});
                this.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(60, GridUnitType.Auto)});

                Score = score;
                Nick = nick;

                //make Nick look better
                while (Nick.StartsWith(" "))
                    Nick = Nick.Remove(0, 1);
                if (Nick == "")
                    Nick = "No name";

                //set score text
                TextBlock scoreTextBlock = new TextBlock();
                scoreTextBlock.Text = String.Format("{0,8}", Score);
                scoreTextBlock.TextAlignment = TextAlignment.Right;
                scoreTextBlock.FontSize = 18;
                Settings.PlaceInGridAndAdd(scoreTextBlock,this,0,0);

                //set nick text block
                TextBlock nickTextBlock = new TextBlock();
                nickTextBlock.Text = Nick;
                nickTextBlock.TextAlignment = TextAlignment.Left;
                nickTextBlock.Margin = new Thickness(10,2,2,2);
                nickTextBlock.FontSize = 18;
                Settings.PlaceInGridAndAdd(nickTextBlock,this,0,1);

            }

            public int CompareTo(ScoreLine other)
            {
                return Score.CompareTo(other.Score);
            }
        }
        
        //window used for geting player nick
        private class NickWindow : Window
        {
            private readonly TextBox _textBox;

            public string Nick => _textBox.Text;

            public NickWindow()
            {
                //set style of window
                this.SizeToContent = SizeToContent.WidthAndHeight;
                this.WindowStyle = WindowStyle.None;

                //set stack main stack panel for this window
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(25);
                Content = stackPanel;

                //let user know whot to do - TextBlock
                TextBlock textBlock = new TextBlock();
                textBlock.FontSize = 30;
                textBlock.Text = "Napiš svoji přezdívku: ";
                stackPanel.Children.Add(textBlock);

                //textBox for user input
                _textBox = new TextBox();
                _textBox.FontSize = 25;
                _textBox.MaxLength = 15;
                stackPanel.Children.Add(_textBox);
                _textBox.Focus();

                //button for closing window
                Button OkButton = new Button();
                OkButton.Content = "OK";
                OkButton.Click += OnOkButtonClick;
                OkButton.Margin = new Thickness(30,5,30,5);
                stackPanel.Children.Add(OkButton);
            }
            //wíndow can be closed by pressing enter to
            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if (e.Key == Key.Enter)
                    Close();
            }

            //close window when ok button pressed
            private void OnOkButtonClick(object sender, RoutedEventArgs e)
            {
                Close();
            }
        }
    }
}
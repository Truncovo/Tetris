using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WindowsAndInput;

namespace TetrisEngine
{
    class MultiPlayer : IWindowSetting
    {
        private TetrisFE _tetrisFirstPlayer;
        private TetrisFE _tetrisSecondPlayer;

        private IKeyLayout _keysFirstPlayer;
        private IKeyLayout _keysSecondPlayer;


        public void SetWindow(GeneralWindow window)
        {
            //window settings
            window.WindowStyle = WindowStyle.None;
            window.SizeToContent = SizeToContent.WidthAndHeight;

            window.Background = Brushes.Black;
            window.Foreground = Brushes.White;

            //main stack panel
          

            //Shared shape generator for both players
            var shapeGenerator = new ShapesGeneratorWithPrediction(3);

            //Creating GameArea for both players
            _tetrisFirstPlayer = new TetrisFE(new Size(16, 8), shapeGenerator);
            _tetrisSecondPlayer = new TetrisFE(new Size(16, 8), shapeGenerator);

            //creating score counter for both players
            var scoreFirstPlayer = new ScoreFE(new ScoreCounter(_tetrisFirstPlayer));
            var scoreSecondPlayer = new ScoreFE(new ScoreCounter(_tetrisSecondPlayer));

            //arange screen
           

            //create stack panel for first player
            StackPanel firstPlayerStack = new StackPanel();
            firstPlayerStack.Children.Add(scoreFirstPlayer);
            firstPlayerStack.Children.Add(_tetrisFirstPlayer);

            //create stack panel for second player
            StackPanel secondPlayerStack = new StackPanel();
            secondPlayerStack.Children.Add(scoreSecondPlayer);
            secondPlayerStack.Children.Add(_tetrisSecondPlayer);

            //add all to main stack panel
            StackPanel mainStack = new StackPanel();
            mainStack.Orientation = Orientation.Horizontal;
            window.Content = mainStack;

            mainStack.Children.Add(firstPlayerStack);
            mainStack.Children.Add(new PredictionFE(shapeGenerator));
            mainStack.Children.Add(secondPlayerStack);

            //creating keycontrol for both players TODO make user settings for this
            _keysFirstPlayer = KeyLayouts.LeftSideOfKeyboardLayout;
            _keysSecondPlayer = KeyLayouts.NumPadArowsLayout;

            //let the game begin
            _tetrisSecondPlayer.Play();
            _tetrisFirstPlayer.Play();
        }

        public void ProcesKeyDown(KeyEventArgs e)
        {
            if (e.Handled)
                return;

            if (!_tetrisFirstPlayer.Playing && !_tetrisSecondPlayer.Playing)
            {
                if (e.Key != Key.Enter)
                    return;

                _tetrisFirstPlayer.Restart();
                _tetrisSecondPlayer.Restart();
                e.Handled = true;
                return;
            }
            _keysFirstPlayer.ProcessKey(_tetrisFirstPlayer, e);
            _keysSecondPlayer.ProcessKey(_tetrisSecondPlayer,e);
        }

        public void ProcesMouseDown(MouseButtonEventArgs e)
        {
        }
    }
}
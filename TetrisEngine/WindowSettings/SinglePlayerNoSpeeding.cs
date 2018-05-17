using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WindowsAndInput;

namespace TetrisEngine
{
    class SinglePlayerNoSpeeding : IWindowSetting
    {
        private TetrisFE _tetrisGrid;
        private IKeyLayout _keyControl;

        public void SetWindow(GeneralWindow window)
        {
            //window settings
            window.WindowStyle = WindowStyle.None;
            window.SizeToContent = SizeToContent.WidthAndHeight;

            window.Background = Brushes.Black;
            window.Foreground = Brushes.White;

            //main stack panel
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            window.Content = stack;

            //insert tetris play area in grid
            _tetrisGrid = new TetrisFE(new Size(16, 8), new AllShapesGeneratorWithPrediction(3));
            stack.Children.Add(_tetrisGrid);
            _tetrisGrid.Play();

            //insert preditction panel and score panel
            stack.Children.Add(new PredictionFE(_tetrisGrid));
            stack.Children.Add(new ScoreHistoryFe(new ScoreCounter(_tetrisGrid)));

            //key control
            _keyControl = KeyLayouts.SinglePlayerLayout;
        }

        public void ProcesKeyDown(KeyEventArgs e)
        {
            if (e.Handled)
                return;
            if (!_tetrisGrid.Playing)
            {
                _tetrisGrid.Restart();
                e.Handled = true;
                return;
            }
            _keyControl.ProcessKey(_tetrisGrid, e);
        }

        public void ProcesMouseDown(MouseButtonEventArgs e)
        {
        }
    }
}
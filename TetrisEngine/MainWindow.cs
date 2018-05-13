using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TetrisEngine
{
    class MainWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new MainWindow());
        }
        private readonly TetrisGrid _tetrisGrid;

        public MainWindow()
        {
            //window settings
            this.WindowStyle = WindowStyle.None;
            this.SizeToContent = SizeToContent.WidthAndHeight;

            this.Background = Brushes.Black;
            this.Foreground = Brushes.White;

            //main stack panel
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            Content = stack;

            //insert tetris play area in grid
            _tetrisGrid = new TetrisGrid(new Size(16,8), new AllShapesGeneratorWithPrediction(3));
            stack.Children.Add( _tetrisGrid);
            _tetrisGrid.Play();

            //insert preditction panel and score panel
            stack.Children.Add(new PredictionStackPanel(_tetrisGrid));
            stack.Children.Add(new ScoreStackPanel(new ScoreCounter(_tetrisGrid)));
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!_tetrisGrid.Playing)
            {
                _tetrisGrid.Restart();
                return;
            }
            switch (e.Key)
            {
                case Key.Right:
                    _tetrisGrid.MoveRight();
                    break;
                case Key.Left:
                    _tetrisGrid.MoveLeft();
                    break;
                case Key.Space:
                    _tetrisGrid.DropToBot();
                    break;
                case Key.A:
                    _tetrisGrid.RotateLeft();
                    break;
                case Key.D:
                    _tetrisGrid.RotateRight();
                    break;
                case Key.Down:
                    _tetrisGrid.MoveDown();
                    break;
            }
        }
    }
}



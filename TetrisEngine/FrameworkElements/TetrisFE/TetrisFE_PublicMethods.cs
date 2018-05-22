using System;
using System.Windows.Media;

namespace TetrisEngine
{
    public partial class TetrisFE 
    {
       


        public void MoveDown()
        {
            if (!Playing) return;
            try
            {
                MoveActualShape(new Coordinates(1,0));
            }
            catch (Exception)
            {
                OnShapeLanded();
                NextShape();
            }
        }

        public void DropToBot()
        {
            if (!Playing) return;

            try
            {
                while(true)
                    MoveActualShape(new Coordinates(1, 0));
            }
            catch (Exception)
            {
                OnShapeLanded();
                NextShape();
            }
        }

        public void MoveRight()
        {
            if (!Playing) return;

            try
            {
                MoveActualShape(new Coordinates(0, 1));
            }
            catch (Exception)
            {
                OnCantMoveLeftOrRight();

            }
        }

        public void MoveLeft()
        {
            if (!Playing) return;

            try
            {
                MoveActualShape(new Coordinates(0, -1));
            }
            catch (Exception)
            {
                OnCantMoveLeftOrRight();
            }
        }

        public void RotateRight()
        {
            if (!Playing) return;

            Rotate(Rotation.Right);
        }

        public void RotateLeft()
        {
            if (!Playing) return;

            Rotate(Rotation.Left);
        }

        public void Rotate(Rotation rotation)
        {

            try
            {
                RotateActiveShape(rotation);
            }
            catch (Exception)
            {
                try
                {
                    TryRotateNearBorders(rotation);
                }
                catch (Exception)
                {

                    OnCantRotate();
                }
            }
        }

        public void Restart()
        {
            this.Children.Clear();
            this.Background = _bgPlayingBrush;
            _spiteArray = new Sprite[Size.X, Size.Y];
            _activeShape = ShapeGenerator.GetShape();
            ShowActualShape();

            OnNewGameStarted(this);
            Play();
        }

    }
}
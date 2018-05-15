using System;
using System.Threading;
using System.Windows;

namespace TetrisEngine
{
    public partial class TetrisFE
    {
        //place actual shape on screen - will throw Exception when shape cant fit in
        private void ShowActualShape()
        {
            foreach (Coordinates coord in _activeShape)
            {
                Coordinates actual = _acticeShapeCoordinates + coord;
                InsertSprite(new Sprite(_activeShape.Color), actual); 
            }
        }
        //delete all sprites of actual shape from screen
        private void HideActualShape()
        {
            foreach (Coordinates coord in _activeShape)
            {
                DeleteSprite(coord + _acticeShapeCoordinates);
            }
        }

        //move actual shape on coordinates - will throw exception when whape can fit into this coordinates
        private void MoveActualShape(Coordinates move)
        {
            Coordinates newCoordinates = _acticeShapeCoordinates + move;
            CanFitIn(_activeShape, newCoordinates);

            HideActualShape();
            _acticeShapeCoordinates = newCoordinates;
            ShowActualShape();
        }

        //check if shape can if  on specified coordinates if not, throws Exception
        private void CanFitIn(Shape shape, Coordinates topLeft)
        {
            foreach (Coordinates coord in shape)
            {
                Coordinates actual = topLeft + coord;
                if (_spiteArray[actual.X, actual.Y] != null && _spiteArray[actual.X, actual.Y].Locked)
                    throw new CantFitInException();
            }
        }

        //all sprites of active shape will be just in spriteArray, will be locked and there will be no active shape
        private void SplitActiveShape()
        {
            foreach (Coordinates coord in _activeShape)
            {
                var AbsolutCoord = coord + _acticeShapeCoordinates;
                _spiteArray[AbsolutCoord.X, AbsolutCoord.Y].Locked = true;
            }
            _activeShape = null;
        }

        //spawn new shape on top center of screen - if shape cant fit there will throw Exception
        private void SpawnShape(Shape shape)
        {
            Coordinates spawn = new Coordinates(0, Size.Y / 2 - shape.Size.Y / 2);

            CanFitIn(shape, spawn);
            _activeShape = shape;
            _acticeShapeCoordinates = spawn;
            ShowActualShape();
        }

        //active shape will be rotated (90°) - if cant fit - will throw exception
        private void RotateActiveShape(Rotation rotation)
        {
            var rotatedShape = _activeShape.GetRotatedCopy(rotation);

            CanFitIn(rotatedShape, _acticeShapeCoordinates);
            HideActualShape();
            _activeShape = rotatedShape;
            ShowActualShape();
        }

        //if map of Shape is not whole in sprite array - will try to move inside sprite array and try to rotate
        //can throw exception if shape cant fit
        private void TryRotateNearBorders(Rotation rotation)
        {
            int ofset = IsShapeBoxOutOfRightBorder();
            if (ofset == 0)
                ofset = IsShapeBoxOutOfLeftBorder();
            if (0 != ofset)
            {
                Shape rotatedShape = _activeShape.GetRotatedCopy(rotation);
                Coordinates newCoordinates =
                    new Coordinates(_acticeShapeCoordinates.X, _acticeShapeCoordinates.Y - ofset);

                CanFitIn(rotatedShape,newCoordinates);
                HideActualShape();
                _acticeShapeCoordinates = newCoordinates;
                _activeShape = rotatedShape;
                ShowActualShape();
            }
           
        }
        //retured int means, how many sprites is shape map outside spriteArray (to left)
        private int IsShapeBoxOutOfLeftBorder()
        {
            if (_acticeShapeCoordinates.Y < 0)
                return _acticeShapeCoordinates.Y;
            return 0;
        }
        
        //retured int means, how many sprites is shape map outside spriteArray (to right)
        private int IsShapeBoxOutOfRightBorder()
        {
            int maxRight = _activeShape.Size.Y + _acticeShapeCoordinates.Y;
            if (Size.Y < maxRight)
                return maxRight - Size.Y;
            return 0;
        }
    }
}
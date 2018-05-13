using System;

namespace TetrisEngine
{
    public partial class TetrisGrid
    {
        //insert sprite to position, if position is full, will throw Exception
        private void InsertSprite(Sprite sprite, Coordinates coord)
        {

            if (_spiteArray[coord.X, coord.Y] != null)
                throw new Exception("ThereIsOne" + coord); //ToDO

            _spiteArray[coord.X, coord.Y] = sprite;
            Settings.PlaceInGridAndAdd(sprite, this, coord.X, coord.Y);
        }

        //cleare coordinates
        private void DeleteSprite(Coordinates coord)
        {
            this.Children.Remove(_spiteArray[coord.X,coord.Y]);
            _spiteArray[coord.X, coord.Y] = null;
        }
        
        //move sprite from frist atribute to second, throw Exception when possition to is full
        private void MoveSpriteFromTo(Coordinates from, Coordinates to)
        {
            if (_spiteArray[to.X, to.Y] != null)
                throw new Exception("ThereIsOne"); //ToDO

            var tmp = _spiteArray[from.X, from.Y];
            _spiteArray[from.X, from.Y] = null;
            Settings.PlaceInGrid(tmp, to.X, to.Y);
            _spiteArray[to.X, to.Y] = tmp;
        }
    }
}
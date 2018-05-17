using System;
using System.Linq;
using System.Windows.Input;

namespace TetrisEngine
{
    public class KeyLayoutSimple : IKeyLayout
    {
        private Key _moveLeft;
        public Key MoveLeft
        {
            get => _moveLeft;
            set
            {
                CheckIfSettingsIsUnique(value);
                _moveLeft = value;
            } 
        }
        private Key _moveRight;
        public Key MoveRight
        {
            get => _moveRight;
            set
            {
                CheckIfSettingsIsUnique(value);
                _moveRight = value;
            }
        }
        private Key _moveDown;
        public Key MoveDown
        {
            get => _moveDown;
            set
            {
                CheckIfSettingsIsUnique(value);
                _moveDown = value;
            }
        }
        private Key _rotateLeft;
        public Key RotateLeft
        {
            get => _rotateLeft;
            set
            {
                CheckIfSettingsIsUnique(value);
                _rotateLeft = value;
            }
        }
        private Key _rotateRight;
        public Key RotateRight
        {
            get => _rotateRight;
            set
            {
                CheckIfSettingsIsUnique(value);
                _rotateRight = value;
            }
        }
        private Key _dropBot;
        public Key DropBot
        {
            get => _dropBot;
            set
            {
                CheckIfSettingsIsUnique(value);
                _dropBot = value;
            }
        }
        
        public Key[] ControlArray { get; set; } = new Key[6];


        public void ProcessKey(ITetrisControl tetrisGrid, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == MoveRight)
                tetrisGrid.MoveRight();
            else if (e.Key == MoveLeft)
                tetrisGrid.MoveLeft();
            else if (e.Key == DropBot)
                tetrisGrid.DropToBot();
            else if (e.Key == RotateLeft)
                tetrisGrid.RotateLeft();
            else if (e.Key == RotateRight)
                tetrisGrid.RotateRight();
            else if (e.Key == MoveDown)
                tetrisGrid.MoveDown();
            else
                e.Handled = false;
        }

        private void CheckIfSettingsIsUnique(Key key)
        {
            //var isUnique = ControlArray.Distinct().Count() == ControlArray.Length;
            //TODO learn with linq
            foreach (var property in typeof(KeyLayoutSimple).GetProperties())
            {
                if(property.PropertyType == typeof(Key) && 
                    property.GetValue(this) != null &&
                    (Key)property.GetValue(this) == key)
                    throw new Exception("aa"); //TODO manage exceptions
            }
            
        }
    }
}
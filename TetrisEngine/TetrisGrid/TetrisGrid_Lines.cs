using System;

namespace TetrisEngine
{
    public partial class TetrisGrid
    {
        private void CheckAndDeleteAllLines()
        {
            for (int x = 0; x < Size.X; x++)
                CheckAndDeleteLine(x);
        }

        private void CheckAndDeleteLine(int line)
        {
            for (int y = 0; y < Size.Y; y++)
            {
                if (_spiteArray[line, y] == null)
                    return;
            }
            ClearLine(line);
            CheckAndDeleteLine(line);
        }

        private void ClearLine(int line)
        {
            Console.WriteLine("CLEARING: " + line);
            for (int y = 0; y < Size.Y; y++)
                DeleteSprite(new Coordinates(line, y));

            OnLineCleared();

            for (int MovingLine = line - 1; MovingLine >= 0; --MovingLine)
            {
                Console.WriteLine("Line" + line);
                MoveLineOneDown(MovingLine);
            }
        }

        private void MoveLineOneDown(int line)
        {
            for (int y = 0; y < Size.Y; y++)
            {
                if (_spiteArray[line, y] != null)
                {
                    MoveSpriteFromTo(new Coordinates(line, y), new Coordinates(line + 1, y));
                }
            }
        }
    }
}
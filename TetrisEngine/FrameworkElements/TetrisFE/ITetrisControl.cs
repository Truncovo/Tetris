namespace TetrisEngine
{
    public interface ITetrisControl
    {
        void MoveDown();
        void DropToBot();
        void MoveRight();
        void MoveLeft();
        void RotateRight();
        void RotateLeft();
        void Rotate(Rotation rotation);
    }
}
namespace TetrisEngine
{
    public interface ITetrisFE
    {
        Size Size { get; }
        void MoveDown();
        void DropToBot();
        void MoveRight();
        void MoveLeft();
        void RotateRight();
        void RotateLeft();
        void Rotate(Rotation rotation);
        event TetrisFeEventHandler NewShapeGenerated;
        event TetrisFeEventHandler GameOver;
        event TetrisFeEventHandler LineCleared;
        event TetrisFeEventHandler ShapeTickDown;
        event TetrisFeEventHandler CantRotate;
        event TetrisFeEventHandler CantMoveLeftOrRight;
        event TetrisFeEventHandler ShapeLanded;
        event TetrisFeEventHandler ShapeGeneratorChanged;
        event TetrisFeEventHandler NewGameStarted;
    }
}
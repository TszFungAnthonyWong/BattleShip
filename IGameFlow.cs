namespace battleship_dotnet
{
    public interface IGameFlow
    {
        void gameSetUp(int[,] gameBoard, string name);
        void gamePlay(int[,] gameBoard, string name);
    }
}
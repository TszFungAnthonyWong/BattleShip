namespace battleship_dotnet.Services.Boards
{
    public interface IBoard
    {
        void addShip(int[,] board, int shipSize);
        int[,] createBoard();
        void showBuildBoard(int[,] board, string player);
    }
}
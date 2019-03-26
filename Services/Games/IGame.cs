namespace battleship_dotnet.Services.Games
{
    public interface IGame
    {
        void fireMissle(int[,] board);
        void showInGameBoard(int[,] board);
        string checkWinner(int[,] board, string player);
    }
}
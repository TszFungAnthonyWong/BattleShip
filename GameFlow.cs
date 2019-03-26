using System;
using battleship_dotnet.Services.Boards;
using battleship_dotnet.Services.Games;


namespace battleship_dotnet
{
    class GameFlow : IGameFlow
    {
        public void gameSetUp(int[,] gameBoard, string name)
        {
            IBoard board = new Board();
            IGame game = new Game();
            for (int i = 1; i < 5; i++)
            {
                board.showBuildBoard(gameBoard, name);
                int shipSize = i + 1;
                board.addShip(gameBoard, shipSize);
            }
            board.showBuildBoard(gameBoard, name);
            Console.ReadLine();
        }

        public void gamePlay(int[,] gameBoard, string name)
        {
            IBoard board = new Board();
            IGame game = new Game();
            Console.WriteLine($"<------!!!{name}'s Trun!!!------>");
            game.showInGameBoard(gameBoard);
            game.fireMissle(gameBoard);
            game.showInGameBoard(gameBoard);

        }
    }
}
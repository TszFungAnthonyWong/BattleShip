using System;
using battleship_dotnet.Services.Boards;
using battleship_dotnet.Services.Games;

namespace battleship_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoard board = new Board();
            IGame game = new Game();
            IGameFlow gameFlow = new GameFlow();

            int[,] gameBoardOne = board.createBoard();
            int[,] gameBoardTwo = board.createBoard();
            string winner = "";
            bool player1Turn = true;
            
            //Game set up
            Console.WriteLine("----------### Battel Ship ###---------- ");

            Console.WriteLine("Please enter player 1 Name:");
            Console.Write(">");
            string p1Name = Console.ReadLine();
            gameFlow.gameSetUp(gameBoardOne, p1Name);

            Console.WriteLine("Please enter player 2 Name");
            Console.Write(">");
            string p2Name = Console.ReadLine();
            gameFlow.gameSetUp(gameBoardTwo, p2Name);

            Console.WriteLine("<------!!!GAME START!!!------>");
            Console.ReadLine();

            //Loop the game when there are no winner 
            while (winner == "")
            {
                if (player1Turn == true)
                {
                    gameFlow.gamePlay(gameBoardTwo,p1Name);
                    winner = game.checkWinner(gameBoardTwo, p1Name);
                    Console.ReadLine();
                    player1Turn = false;
                }
                else
                {
                    gameFlow.gamePlay(gameBoardOne,p2Name);
                    winner = game.checkWinner(gameBoardOne, p2Name);
                    Console.ReadLine();
                    player1Turn = true;
                }
            }
            Console.WriteLine($"Player {winner} has win the game !!!!!!!!");
        }
    }

    
    
}

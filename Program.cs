using System;
namespace battleship_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Game game = new Game();
            const int GAMEBOARDWIDTH = 10;
            const int GAMEBOARDHEIGTH = 10;
            int[,] gameBoardOne = board.createBoard(GAMEBOARDHEIGTH, GAMEBOARDWIDTH);
            int[,] gameBoardTwo = board.createBoard(GAMEBOARDHEIGTH, GAMEBOARDWIDTH);
            string winner = "";
            bool player1Turn = true;
            
            //Game set up
            Console.WriteLine("----------### Battel Ship ###---------- ");
            Console.WriteLine("Please enter player 1 Name:");
            Console.Write(">");
            string p1Name = Console.ReadLine();
            for (int i = 1; i < 5; i++)
            {
                board.showBuildBoard(gameBoardOne, p1Name);
                int shipSize = i + 1;
                board.addShip(gameBoardOne, shipSize);
            }
            board.showBuildBoard(gameBoardOne, p1Name);
            Console.ReadLine();

            Console.WriteLine("Please enter player 2 Name");
            Console.Write(">");
            string p2Name = Console.ReadLine();
            for (int i = 1; i < 5; i++)
            {
                board.showBuildBoard(gameBoardTwo, p2Name);
                int shipSize = i + 1;
                board.addShip(gameBoardTwo, shipSize);
            }
            board.showBuildBoard(gameBoardTwo, p2Name);
            Console.ReadLine();

            Console.WriteLine("<------!!!GAME START!!!------>");
            Console.ReadLine();

            //Loop the game when there are no winner 
            while (winner == "")
            {
                if (player1Turn == true)
                {
                    Console.WriteLine($"<------!!!{p1Name}'s Trun!!!------>");
                    game.showInGameBoard(gameBoardTwo);
                    game.fireMissle(gameBoardTwo);
                    game.showInGameBoard(gameBoardTwo);
                    winner = game.checkWinner(gameBoardTwo, p1Name);
                    Console.ReadLine();
                    player1Turn = false;
                }
                else
                {
                    Console.WriteLine($"<------!!!{p2Name}'s Trun!!!------>");
                    game.showInGameBoard(gameBoardOne);
                    game.fireMissle(gameBoardOne);
                    game.showInGameBoard(gameBoardOne);
                    winner = game.checkWinner(gameBoardOne, p2Name);
                    Console.ReadLine();
                    player1Turn = true;
                }
            }

            Console.WriteLine($"Player {winner} has win the game !!!!!!!!");
        }
    }
    
}

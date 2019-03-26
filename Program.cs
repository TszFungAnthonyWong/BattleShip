using System;

namespace battleship_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board();
            Game g = new Game();
            int gameboardWidth = 2;
            int gameboardHeight = 2;
            int[,] gameBoardOne = b.createBoard(gameboardHeight, gameboardWidth);
            int[,] gameBoardTwo = b.createBoard(gameboardHeight, gameboardWidth);
            string winner = "";
            Boolean player1Turn = true;

            Console.WriteLine("----------### Battel Ship ###---------- ");
            Console.WriteLine("Please enter player 1 Name:");
            Console.Write(">");
            string p1Name = Console.ReadLine();
            for (int i = 1; i < 2; i++)
            {
                b.showBuildBoard(gameBoardOne, p1Name);
                int shipSize = i + 1;
                b.addShip(gameBoardOne, shipSize);
            }
            b.showBuildBoard(gameBoardOne, p1Name);
            Console.ReadLine();

            Console.WriteLine("Please enter player 2 Name");
            Console.Write(">");
            string p2Name = Console.ReadLine();
            for (int i = 1; i < 2; i++)
            {
                b.showBuildBoard(gameBoardTwo, p2Name);
                int shipSize = i + 1;
                b.addShip(gameBoardTwo, shipSize);
            }
            b.showBuildBoard(gameBoardTwo, p2Name);
            Console.ReadLine();

            Console.WriteLine("<------!!!GAME START!!!------>");
            Console.ReadLine();
            while (winner == "")
            {
                if (player1Turn == true)
                {
                    Console.WriteLine($"<------!!!{p1Name}'s Trun!!!------>");
                    g.showInGameBoard(gameBoardTwo);
                    g.fireMissle(gameBoardTwo);
                    g.showInGameBoard(gameBoardTwo);
                    winner = g.checkWinner(gameBoardTwo, p1Name);

                    Console.WriteLine();
                    Console.ReadLine();
                    player1Turn = false;
                }
                else
                {
                    Console.WriteLine($"<------!!!{p2Name}'s Trun!!!------>");
                    g.showInGameBoard(gameBoardOne);
                    g.fireMissle(gameBoardOne);
                    g.showInGameBoard(gameBoardOne);
                    winner = g.checkWinner(gameBoardOne, p2Name);
                    Console.ReadLine();
                    player1Turn = true;
                }
            }

            Console.WriteLine($"Player {winner} has win the game !!!!!!!!");
        }
    }
    class Board
    {
        public void addShip(int[,] board, int shipSize)
        {
            int row = board.GetLength(0);
            int column = board.GetLength(1);
            int xPosition;
            int yPosition;
            int direction;
            string inputString;
            Console.WriteLine("Ship size: 1 X " + shipSize);

            Console.Write("Enter X: ");
            inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out xPosition) || xPosition > column || xPosition < 0)
            {
                Console.WriteLine("Invalide input, please enter again");
                Console.Write(">");
                inputString = Console.ReadLine();
            }

            Console.Write("Enter Y: ");
            inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out yPosition) || yPosition > row || yPosition < 0)
            {
                Console.WriteLine("Invalide input, please enter again");
                Console.Write(">");
                inputString = Console.ReadLine();
            }

            Console.WriteLine("Please enter the interger for Direction:");
            Console.WriteLine("1 Horzontal");
            Console.WriteLine("2 Vertical");
            Console.Write(">");
            inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out direction) || direction > 2 || direction < 1)
            {
                Console.WriteLine("Invalide input, please enter again");
                Console.Write(">");
                inputString = Console.ReadLine();
            }

            if (direction == 1) //horizontal Add
            {
                if (xPosition + shipSize <= column)
                {
                    Boolean collaps = false;
                    for (int counter = 0; counter < shipSize; counter++)
                    {
                        if (board[yPosition, xPosition + counter] != 0)
                        {
                            collaps = true;
                        }
                    }
                    if (collaps == false)
                    {
                        for (int counter = 0; counter < shipSize; counter++)
                        {
                            board[yPosition, xPosition + counter] = shipSize;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Horisotal collaps, Please Re-Enter");
                        addShip(board, shipSize);
                    }
                }
                else
                {
                    Console.WriteLine("Out of Space,  Please Re-Enter");
                    addShip(board, shipSize);
                }

            }
            else    //Vertical Add
            {
                if (yPosition + shipSize <= row)
                {
                    Boolean collaps = false;
                    for (int counter = 0; counter < shipSize; counter++)
                    {
                        if (board[yPosition + counter, xPosition] != 0)
                        {
                            collaps = true;
                        }
                    }
                    if (collaps == false)
                    {
                        for (int counter = 0; counter < shipSize; counter++)
                        {
                            board[yPosition + counter, xPosition] = shipSize;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vertical collaps,  Please Re-Enter");
                        addShip(board, shipSize);
                    }
                }
                else
                {
                    Console.WriteLine("Out of Space,  Please Re-Enter");
                    addShip(board, shipSize);
                }
            }
        }
        public int[,] createBoard(int row, int column)
        {

            int[,] board = new int[row, column];
            for (int rowCounter = 0; rowCounter < board.GetLength(0); rowCounter++)
            {
                for (int columnCounter = 0; columnCounter < board.GetLength(1); columnCounter++)
                {
                    board[rowCounter, columnCounter] = 0;
                }
            }
            return board;
        }
        public void showBuildBoard(int[,] board, string player)
        {
            Console.WriteLine($"-----{player}'s game board-----" + Environment.NewLine);
            Console.Write("    ");
            for (int columnCounter = 0; columnCounter < board.GetLength(1); columnCounter++)
            {
                Console.Write($"{columnCounter} ");
            }
            Console.Write("X");
            Console.Write(Environment.NewLine + Environment.NewLine);

            for (int rowCounter = 0; rowCounter < board.GetLength(0); rowCounter++)
            {
                Console.Write(string.Format("{0}   ", rowCounter));
                for (int columnCounter = 0; columnCounter < board.GetLength(1); columnCounter++)
                {
                    if (board[rowCounter, columnCounter] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(string.Format("{0 } ", board[rowCounter, columnCounter]));
                    }

                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("Y");
        }
    }
    class Game
    {
        public void fireMissle(int[,] board)
        {
            string inputString;
            int xPosition;
            int yPosition;
            int row = board.GetLength(0);
            int column = board.GetLength(1);

            Console.Write("Enter X: ");
            inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out xPosition) || xPosition > column || xPosition < 0)
            {
                Console.WriteLine("Invalide input, please enter again");
                Console.Write(">");
                inputString = Console.ReadLine();
            }

            Console.Write("Enter Y: ");
            inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out yPosition) || yPosition > row || yPosition < 0)
            {
                Console.WriteLine("Invalide input, please enter again");
                Console.Write(">");
                inputString = Console.ReadLine();
            }

            switch (board[yPosition, xPosition])
            {
                case 0:
                    board[yPosition, xPosition] = -2;
                    Console.WriteLine("<---------MISS--------->");
                    break;
                case -1:
                    Console.WriteLine("This position already HIT!!! Please select other position");
                    fireMissle(board);
                    break;
                case -2:
                    Console.WriteLine("This position is emty!! Please enter other position");
                    fireMissle(board);
                    break;
                default:
                    board[yPosition, xPosition] = -1;
                    Console.WriteLine("<------!!!HIT!!!------>");
                    break;
            }
        }

        public void showInGameBoard(int[,] board)
        {
            Console.Write("    ");
            for (int columnCounter = 0; columnCounter < board.GetLength(1); columnCounter++)
            {
                Console.Write($"{columnCounter} ");
            }
            Console.Write("X");
            Console.Write(Environment.NewLine + Environment.NewLine);

            for (int rowCounter = 0; rowCounter < board.GetLength(0); rowCounter++)
            {
                Console.Write(string.Format("{0}   ", rowCounter));
                for (int columnCounter = 0; columnCounter < board.GetLength(1); columnCounter++)
                {
                    switch (board[rowCounter, columnCounter])
                    {
                        case -1:
                            Console.Write("H ");
                            break;
                        case -2:
                            Console.Write("M ");
                            break;
                        default:
                            Console.Write("  ");
                            break;
                    }

                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("Y");
        }

        public string checkWinner(int[,] board, string player)
        {
            string winner;
            Boolean win = true;
            for (int rowCounter = 0; rowCounter < board.GetLength(0); rowCounter++)
            {
                for (int columnCounter = 0; columnCounter < board.GetLength(1); columnCounter++)
                {
                    if (board[rowCounter, columnCounter] > 0)
                    {
                        win = false;
                    }
                }
            }
            if (win == true)
            {
                winner = player;
            }
            else
            {
                winner = "";
            }
            return winner;
        }
    }
}

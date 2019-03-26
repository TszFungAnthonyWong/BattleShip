using System;

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
                    board[yPosition, xPosition] = (int)BoardEnum.Miss;
                    Console.WriteLine("<---------MISS--------->");
                    break;
                case (int)BoardEnum.Hit:
                    Console.WriteLine("This position already HIT!!! Please select other position");
                    fireMissle(board);
                    break;
                case (int)BoardEnum.Miss:
                    Console.WriteLine("This position is emty!! Please enter other position");
                    fireMissle(board);
                    break;
                default:
                    board[yPosition, xPosition] = (int)BoardEnum.Hit;
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
                        case (int)BoardEnum.Hit:
                            Console.Write("H ");
                            break;
                        case (int)BoardEnum.Miss:
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
            bool win = true;
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
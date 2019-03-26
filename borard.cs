
using System;

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
                if (xPosition + shipSize <= column) // check if the position are possible
                {
                    bool collaps = false;
                    for (int counter = 0; counter < shipSize; counter++) // check the slot availibity
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
                    bool collaps = false;
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
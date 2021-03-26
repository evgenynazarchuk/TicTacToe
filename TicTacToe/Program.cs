using System;

namespace TicTacToe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // input data
            char[,] gameField = new char[3, 3];
            int currentPlayer = 1;
            char userSymbol = ' ';
            bool correctInput = true;
            bool gameOver = false;
            int userInputCellNumber;
            int cellNumber;
            
            // game cycle
            while (!gameOver)
            {
                Console.Clear();
                correctInput = true;

                // print game field
                cellNumber = 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (gameField[i, j] == 0)
                        {
                            Console.Write(cellNumber);
                        }
                        else
                        {
                            Console.Write(gameField[i, j]);
                        }
                        Console.Write(" ");
                        cellNumber++;
                    }
                    Console.WriteLine();
                }

                // input data
                Console.Write(currentPlayer == 1 ? "Gamer X, " : "Gamer O, ");
                Console.Write("enter field number: ");
                

                try
                {
                    userInputCellNumber = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    continue;
                }

                // check cell
                cellNumber = 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (cellNumber == userInputCellNumber && gameField[i, j] != 0)
                        {
                            correctInput = false;
                        }
                        cellNumber++;
                    }
                }

                if (correctInput == false)
                {
                    // input again
                    continue;
                }
                else
                {
                    // set cell value
                    userSymbol = currentPlayer == 1 ? 'X' : 'O';
                    cellNumber = 1;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (cellNumber == userInputCellNumber)
                            {
                                gameField[i, j] = userSymbol;
                                correctInput = true;
                            }
                            cellNumber++;
                        }
                    }
                }

                // check result
                if (gameField[0, 0] == userSymbol && gameField[0, 1] == userSymbol && gameField[0, 2] == userSymbol)
                    gameOver = true;
                if (gameField[1, 0] == userSymbol && gameField[1, 1] == userSymbol && gameField[1, 2] == userSymbol)
                    gameOver = true;
                if (gameField[2, 0] == userSymbol && gameField[2, 1] == userSymbol && gameField[2, 2] == userSymbol)
                    gameOver = true;

                if (gameField[0, 0] == userSymbol && gameField[1, 0] == userSymbol && gameField[2, 0] == userSymbol)
                    gameOver = true;
                if (gameField[0, 1] == userSymbol && gameField[1, 1] == userSymbol && gameField[2, 1] == userSymbol)
                    gameOver = true;
                if (gameField[0, 2] == userSymbol && gameField[1, 2] == userSymbol && gameField[2, 2] == userSymbol)
                    gameOver = true;

                if (gameField[0, 0] == userSymbol && gameField[1, 1] == userSymbol && gameField[2, 2] == userSymbol)
                    gameOver = true;
                if (gameField[0, 2] == userSymbol && gameField[1, 1] == userSymbol && gameField[2, 0] == userSymbol)
                    gameOver = true;

                if (gameOver)
                {
                    Console.Clear();

                    // print game field
                    cellNumber = 1;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (gameField[i, j] == 0)
                            {
                                Console.Write(cellNumber);
                            }
                            else
                            {
                                Console.Write(gameField[i, j]);
                            }
                            Console.Write(" ");
                            cellNumber++;
                        }
                        Console.WriteLine();
                    }

                    Console.Write($"Congratulations winner player {currentPlayer}");
                    break;
                }
                else
                {
                    // change player
                    currentPlayer = currentPlayer == 1 ? 2 : 1;
                }
            }
        }
    }
}

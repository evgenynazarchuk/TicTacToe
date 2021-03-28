using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.BLL
{
    public class TicTocToe
    {
        public GameStatus GameStatus { get; private set; } = GameStatus.Play;
        public char[,] GameField { get; set; } = new char[3, 3];

        public int CurrentPlayer { get; private set; } = 1;
        public char UserSymbol { get; private set; } = 'X';

        public TicTocToe()
        {
        }

        public bool FindMatches()
        {
            bool gameOver = false;

            if (this.GameField[0, 0] == this.UserSymbol && this.GameField[0, 1] == this.UserSymbol && this.GameField[0, 2] == this.UserSymbol)
            {
                gameOver = true;
            }
            else if (this.GameField[1, 0] == this.UserSymbol && this.GameField[1, 1] == this.UserSymbol && this.GameField[1, 2] == this.UserSymbol)
            {
                gameOver = true;
            }
            else if (this.GameField[2, 0] == this.UserSymbol && this.GameField[2, 1] == this.UserSymbol && this.GameField[2, 2] == this.UserSymbol)
            {
                gameOver = true;
            }

            else if (this.GameField[0, 0] == this.UserSymbol && this.GameField[1, 0] == this.UserSymbol && this.GameField[2, 0] == this.UserSymbol)
            {
                gameOver = true;
            }
            else if (this.GameField[0, 1] == this.UserSymbol && this.GameField[1, 1] == this.UserSymbol && this.GameField[2, 1] == this.UserSymbol)
            {
                gameOver = true;
            }
            else if (this.GameField[0, 2] == this.UserSymbol && this.GameField[1, 2] == this.UserSymbol && this.GameField[2, 2] == this.UserSymbol)
            {
                gameOver = true;
            }

            else if (this.GameField[0, 0] == this.UserSymbol && this.GameField[1, 1] == this.UserSymbol && this.GameField[2, 2] == this.UserSymbol)
            {
                gameOver = true;
            }
            else if (this.GameField[0, 2] == this.UserSymbol && this.GameField[1, 1] == this.UserSymbol && this.GameField[2, 0] == this.UserSymbol)
            {
                gameOver = true;
            }

            if (gameOver)
            {
                this.GameStatus = GameStatus.GameOver;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidCellNumber(int number)
        {
            if (number >= 1 && number <= 9)
            {
                return true;
            }
            return false;
        }

        public char GetCellValueByPosition(CellPosition cellPosition)
        {
            return this.GameField[cellPosition.i, cellPosition.j];
        }

        public CellPosition FindCellPositionByNumber(int number)
        {
            int cellNumber = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cellNumber == number)
                    {
                        return new CellPosition(i, j);
                    }
                    cellNumber++;
                }
            }
            throw new ApplicationException("The number must be between 1 and 9.");
        }

        public bool CheckAccessCellByPosition(CellPosition cellPostion)
        {
            if (this.GetCellValueByPosition(cellPostion) == 0)
                return true;
            else return false;
        }

        public void SetCellSymbol(CellPosition cellPosition)
        {
            this.GameField[cellPosition.i, cellPosition.j] = this.UserSymbol;
        }

        public void ChangePlayer()
        {
            this.CurrentPlayer = this.CurrentPlayer == 1 ? 2 : 1;
            this.UserSymbol = this.CurrentPlayer == 1 ? 'X' : 'O';
        }

        public void PrintGameField()
        {
            int cellNumber = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.GameField[i, j] == 0)
                    {
                        Console.Write(cellNumber);
                    }
                    else
                    {
                        Console.Write(this.GameField[i, j]);
                    }
                    Console.Write(" ");
                    cellNumber++;
                }
                Console.WriteLine();
            }
        }

        public void PrintWinner()
        {
            Console.Write($"Congratulations winner player {this.CurrentPlayer}");
        }
    }
}

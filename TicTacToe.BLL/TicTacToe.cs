using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.BLL.Interfaces;

namespace TicTacToe.BLL
{
    public class TicTacToe
    {
        private readonly IRepository _repository;

        public TicTacToe(IRepository repository)
        {
            this._repository = repository;
        }

        public void InitMemory(
            char[,] gameField
            , GameStatus gameStatus = GameStatus.Play
            , int currentPlayer = 1
            , char userSymbol = 'X'
            )
        {
            this._repository.GameField = gameField;
            this._repository.GameStatus = gameStatus;
            this._repository.CurrentPlayer = currentPlayer;
            this._repository.UserSymbol = userSymbol;
        }

        public bool FindMatches()
        {
            bool gameOver = false;

            if (this._repository.GameField[0, 0] == this._repository.UserSymbol && this._repository.GameField[0, 1] == this._repository.UserSymbol && this._repository.GameField[0, 2] == this._repository.UserSymbol)
            {
                gameOver = true;
            }
            else if (this._repository.GameField[1, 0] == this._repository.UserSymbol && this._repository.GameField[1, 1] == this._repository.UserSymbol && this._repository.GameField[1, 2] == this._repository.UserSymbol)
            {
                gameOver = true;
            }
            else if (this._repository.GameField[2, 0] == this._repository.UserSymbol && this._repository.GameField[2, 1] == this._repository.UserSymbol && this._repository.GameField[2, 2] == this._repository.UserSymbol)
            {
                gameOver = true;
            }

            else if (this._repository.GameField[0, 0] == this._repository.UserSymbol && this._repository.GameField[1, 0] == this._repository.UserSymbol && this._repository.GameField[2, 0] == this._repository.UserSymbol)
            {
                gameOver = true;
            }
            else if (this._repository.GameField[0, 1] == this._repository.UserSymbol && this._repository.GameField[1, 1] == this._repository.UserSymbol && this._repository.GameField[2, 1] == this._repository.UserSymbol)
            {
                gameOver = true;
            }
            else if (this._repository.GameField[0, 2] == this._repository.UserSymbol && this._repository.GameField[1, 2] == this._repository.UserSymbol && this._repository.GameField[2, 2] == this._repository.UserSymbol)
            {
                gameOver = true;
            }

            else if (this._repository.GameField[0, 0] == this._repository.UserSymbol && this._repository.GameField[1, 1] == this._repository.UserSymbol && this._repository.GameField[2, 2] == this._repository.UserSymbol)
            {
                gameOver = true;
            }
            else if (this._repository.GameField[0, 2] == this._repository.UserSymbol && this._repository.GameField[1, 1] == this._repository.UserSymbol && this._repository.GameField[2, 0] == this._repository.UserSymbol)
            {
                gameOver = true;
            }

            if (gameOver)
            {
                this._repository.GameStatus = GameStatus.GameOver;
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
            return this._repository.GameField[cellPosition.i, cellPosition.j];
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
            this._repository.GameField[cellPosition.i, cellPosition.j] = this._repository.UserSymbol;
        }

        public void ChangePlayer()
        {
            this._repository.CurrentPlayer = this._repository.CurrentPlayer == 1 ? 2 : 1;
            this._repository.UserSymbol = this._repository.CurrentPlayer == 1 ? 'X' : 'O';
        }

        public void SetUserSymbol(char symbol)
        {
            this._repository.UserSymbol = symbol;
        }

        public void SetGameField(char[,] gameField)
        {
            this._repository.GameField = gameField;
        }

        public void PrintGameField()
        {
            int cellNumber = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this._repository.GameField[i, j] == 0)
                    {
                        Console.Write(cellNumber);
                    }
                    else
                    {
                        Console.Write(this._repository.GameField[i, j]);
                    }
                    Console.Write(" ");
                    cellNumber++;
                }
                Console.WriteLine();
            }
        }

        public void PrintWinner()
        {
            Console.Write($"Congratulations winner player {this._repository.CurrentPlayer}");
        }

        public GameStatus GetGameStatus() => this._repository.GameStatus;
        public int GetCurrentPlayer() => this._repository.CurrentPlayer;
    }
}

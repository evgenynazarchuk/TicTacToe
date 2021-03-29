using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeApp.BLL.Interfaces;

namespace TicTacToeApp.BLL
{
    public class TicTacToe
    {
        private readonly IRepository _repository;
        private readonly IDisplay _display;
        private readonly IController _controller;

        public TicTacToe(
            IRepository repository
            , IDisplay display
            , IController controller
            )
        {
            this._repository = repository;
            this._display = display;
            this._controller = controller;
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

        public void Start()
        {
            this.InitMemory(new char[3, 3], GameStatus.Play, 1, 'X');
            int userInputCellNumber;

            while (this.GetGameStatus() != GameStatus.GameOver)
            {
                _display.PrintGameField(_repository.GameField);

                var playerName = this.GetCurrentPlayer() == 1 ? "Gamer X, " : "Gamer O, ";
                var welcomeInput = "enter field number: " + playerName;
                this._display.PrintWaitInput(welcomeInput);
                try
                {
                    userInputCellNumber = _controller.WaitUserInput();
                }
                catch (Exception)
                {
                    continue;
                }

                if (!this.IsValidCellNumber(userInputCellNumber))
                {
                    continue;
                }

                var cellPosition = this.FindCellPositionByNumber(userInputCellNumber);
                if (this.CheckAccessCellByPosition(cellPosition))
                {
                    this.SetCellSymbol(cellPosition);
                }
                else
                {
                    continue;
                }

                if (this.FindMatches())
                {
                    _display.PrintGameField(_repository.GameField);
                    _display.PrintWinner($"Congratulations winner player {this.GetCurrentPlayer()}");
                    break;
                }
                else
                {
                    this.ChangePlayer();
                }
            }
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

        public GameStatus GetGameStatus() => this._repository.GameStatus;
        public int GetCurrentPlayer() => this._repository.CurrentPlayer;
    }
}

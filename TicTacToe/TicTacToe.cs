using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class TicTacToe
    {
        private char[,] _gameField = new char[3, 3];
        public TicTacToe()
        {

        }
        public string GetWinner()
        {
            throw new Exception();
        }
        public (int, int) GetCellByNumber(int cellNumber)
        {
            int cell = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cell++;
                    if (cell == cellNumber)
                    {
                        return (i, j);
                    }
                }
            }
            throw new Exception("Not found cell coord by number");
        }
        public bool CheckStatusCell(int cellNumber)
        {
            var (i, j) = this.GetCellByNumber(cellNumber);
            return _gameField[i, j] == 0 ? true : false;
        }
        public void SelectCell(int cellNumber, char symbol)
        {
            var (i, j) = GetCellByNumber(cellNumber);
            _gameField[i, j] = symbol;
        }
        public bool CheckGameResult(char symbol)
        {
            if (_gameField[0, 0] == symbol && _gameField[0, 1] == symbol && _gameField[0, 2] == symbol)
                return true;
            if (_gameField[1, 0] == symbol && _gameField[1, 1] == symbol && _gameField[1, 2] == symbol)
                return true;
            if (_gameField[2, 0] == symbol && _gameField[2, 1] == symbol && _gameField[2, 2] == symbol)
                return true;

            if (_gameField[0, 0] == symbol && _gameField[1, 0] == symbol && _gameField[2, 0] == symbol)
                return true;
            if (_gameField[0, 1] == symbol && _gameField[1, 1] == symbol && _gameField[2, 1] == symbol)
                return true;
            if (_gameField[0, 2] == symbol && _gameField[1, 2] == symbol && _gameField[2, 2] == symbol)
                return true;

            if (_gameField[0, 0] == symbol && _gameField[1, 1] == symbol && _gameField[2, 2] == symbol)
                return true;
            if (_gameField[0, 2] == symbol && _gameField[1, 1] == symbol && _gameField[2, 0] == symbol)
                return true;

            return false;
        }
        public void PrintGameField()
        {
            int cell = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cell++;
                    if (CheckStatusCell(cell))
                    {
                        Console.Write($"{cell}  ");
                    }
                    else 
                    {
                        Console.Write($"{_gameField[i, j]}  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

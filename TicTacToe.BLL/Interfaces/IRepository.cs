using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL.Interfaces
{
    public interface IRepository
    {
        public GameStatus GameStatus { get; set; }
        public char[,] GameField { get; set; }
        public int CurrentPlayer { get; set; }
        public char UserSymbol { get; set; }
        public void Init(char[,] gameField, GameStatus gameStatus, int currentPlayer, char userSymbol);
    }
}

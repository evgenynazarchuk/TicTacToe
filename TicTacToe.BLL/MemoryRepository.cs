using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL.Interfaces;

namespace TicTacToe.BLL
{
    public class MemoryRepository : IRepository
    {
        public char[,] GameField { get; set; }
        public GameStatus GameStatus { get; set; }
        public int CurrentPlayer { get; set; }
        public char UserSymbol { get; set; }
        public void Init(char[,] gameField, GameStatus gameStatus, int currentPlayer, char userSymbol)
        {
            this.GameField = gameField;
            this.GameStatus = gameStatus;
            this.CurrentPlayer = currentPlayer;
            this.UserSymbol = userSymbol;
        }
    }
}

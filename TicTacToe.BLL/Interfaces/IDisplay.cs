using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL.Interfaces
{
    public interface IDisplay
    {
        public void PrintGameField(char[,] gameField);
        public void PrintWinner(string congratulation);
        public void UpdateDisplay();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApp.BLL.Interfaces
{
    public interface IDisplay
    {
        public void PrintGameField(char[,] gameField);
        public void PrintWinner(string congratulation);
        public void PrintWaitInput(string welcome);
        public void ClearDisplay();
    }
}

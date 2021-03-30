using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.BLL.Interfaces;

namespace TicTacToeApp.BLL
{
    public class ConsoleDisplay : IDisplay
    {
        public void PrintGameField(char[,] gameField)
        {
            this.ClearDisplay();

            int cellNumber = 1;
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
        }

        public void PrintWaitInput(string welcome)
        {
            Console.WriteLine(welcome);
        }

        public void PrintWinner(string congratulation)
        {
            Console.WriteLine(congratulation);
        }

        public void ClearDisplay()
        {
            Console.Clear();
        }
    }
}

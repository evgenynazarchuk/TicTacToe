using System;
using TicTacToeApp.BLL;

namespace TicTacToeApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var memory = new MemoryRepository();
            var output = new ConsoleDisplay();
            var controller = new ConsoleController();
            var game = new TicTacToe(memory, output, controller);
            game.Start();
        }
    }
}

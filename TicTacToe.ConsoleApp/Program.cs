using System;
using TicTacToe.BLL;

namespace TicTacToe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var memory = new MemoryRepository();
            var game = new BLL.TicTacToe(memory);
            game.InitMemory(new char[3, 3], GameStatus.Play, 1, 'X');
            int userInputCellNumber;

            while (game.GetGameStatus() != GameStatus.GameOver)
            {
                Console.Clear();
                game.PrintGameField();

                Console.Write(game.GetCurrentPlayer() == 1 ? "Gamer X, " : "Gamer O, ");
                Console.Write("enter field number: ");
                try
                {
                    userInputCellNumber = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    continue;
                }

                var cellPosition = game.FindCellPositionByNumber(userInputCellNumber);
                if (game.CheckAccessCellByPosition(cellPosition))
                {
                    game.SetCellSymbol(cellPosition);
                }
                else
                {
                    continue;
                }

                if (game.FindMatches())
                {
                    Console.Clear();
                    game.PrintGameField();
                    Console.Write($"Congratulations winner player {game.GetCurrentPlayer()}");
                    break;
                }
                else
                {
                    game.ChangePlayer();
                }
            }
        }
    }
}

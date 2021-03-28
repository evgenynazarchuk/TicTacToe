using System;
using TicTacToe.BLL;

namespace TicTacToe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BLL.TicTacToe();
            int userInputCellNumber;

            while (game.GameStatus != GameStatus.GameOver)
            {
                Console.Clear();
                game.PrintGameField();

                Console.Write(game.CurrentPlayer == 1 ? "Gamer X, " : "Gamer O, ");
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
                    Console.Write($"Congratulations winner player {game.CurrentPlayer}");
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

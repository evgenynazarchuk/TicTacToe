using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.BLL.Interfaces;

namespace TicTacToeApp.BLL
{
    public class ConsoleController : IController
    {
        public int WaitUserInput()
        {
            int userInputCellNumber;
            try
            {
                userInputCellNumber = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new ApplicationException("Invalid number");
            }
            return userInputCellNumber;
        }
    }
}

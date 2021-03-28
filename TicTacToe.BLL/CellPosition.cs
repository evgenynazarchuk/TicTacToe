using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public class CellPosition
    {
        public readonly int i;
        public readonly int j;

        public CellPosition(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestLine.Battleship.BattleshipLogic.Tools
{
    internal class VectorParser
    {
        public static Vector2d ParseVector(string input)
        {
            int x ="abcdefghij".IndexOf(input[0]);
            int y = int.Parse(""+input[1]) ;
            return new Vector2d(x, y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestLine.Battleship.BattleshipLogic.Tools
{
    internal class Vector2d
    {
        public Vector2d(int x, int y)
        {

            this.x = x;
            this.y = y;
        }
        int x;
        int y;

        public int X { get => x; }
        public int Y { get => y; }

        internal bool IsEqual(Vector2d vector2D)
        {
            if (x == vector2D.X && y == vector2D.Y)
            {
                return true;
            }
            return false;
        }
    }
}

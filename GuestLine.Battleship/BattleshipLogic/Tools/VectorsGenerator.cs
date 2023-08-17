using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestLine.Battleship.BattleshipLogic.Tools
{
    internal class VectorsGenerator
    {
        public static List<Vector2d> GenerateVectorsBetween(Vector2d start, Vector2d end, int length)
        {
            List<Vector2d> result = new List<Vector2d>();
            for (int i = 0; i < length; i++)
            {
                result.Add(new Vector2d(
                    (start.X * (length - i) + end.X * i) / length,
                    (start.Y * (length - i) + end.Y * i) / length
                    ));
            }
            return result;
        }
    }
}

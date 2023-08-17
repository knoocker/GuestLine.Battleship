using GuestLine.Battleship.BattleshipLogic.Ships;
using GuestLine.Battleship.BattleshipLogic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestLine.Battleship.BattleshipLogic.Game
{
    internal class ShipsFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipSize"> ship length </param>
        /// <param name="bardMaxSize"> size of game board</param>
        /// <param name="shipsOnBoard"> list of ships witch already are on game board</param>
        /// <returns></returns>
        public Ship CreateShip(int shipSize, int bardMaxSize,List<Ship> shipsOnBoard)
        {
            Random random = new Random();
            while (true)
            {
                int horizontalMultiply = random.Next(2);
                Vector2d start = new Vector2d(random.Next(bardMaxSize - shipSize*horizontalMultiply), random.Next(bardMaxSize - shipSize * (1-horizontalMultiply)));
                Vector2d end = new Vector2d(start.X + shipSize*horizontalMultiply, start.Y+ shipSize * (1 - horizontalMultiply));
                List<Vector2d> vector2Ds = VectorsGenerator.GenerateVectorsBetween(start, end, shipSize);
                if (!IsShipsCollideToVectors(shipsOnBoard, vector2Ds))
                {
                    return new Ship(vector2Ds);
                }

            }
        }


        /// <summary>
        /// Can we put random ship on the game board?
        /// </summary>
        /// <param name="shipList"></param>
        /// <param name="vector2Ds"></param>
        /// <returns></returns>
        private bool IsShipsCollideToVectors(List<Ship> shipList, List<Vector2d> vector2Ds)
        {
            foreach (var ship in shipList)
            {
                foreach(var vector2d in vector2Ds)
                {
                    if (ship.CointainsVector(vector2d))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

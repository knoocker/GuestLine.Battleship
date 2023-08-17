using GuestLine.Battleship.BattleshipLogic.Ships;
using GuestLine.Battleship.BattleshipLogic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GuestLine.Battleship.BattleshipLogic.Game
{
    internal class Game
    {
        List<Ship> ships;
        readonly int boardSize = 10;

        public Game() {
            RestartGame();
        }

        private void RestartGame()
        {
            ships = new List<Ship>();
            ShipsFactory factory = new ShipsFactory();
            ships.Add(factory.CreateShip(5, boardSize, ships));
            ships.Add(factory.CreateShip(4, boardSize, ships));
            ships.Add(factory.CreateShip(4, boardSize, ships));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DrawBoard()
        {
            string board = "  0123456789\r\na ";
            string alphabet = "abcdefghijkl";
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    bool isBoard = false;
                    foreach (var ship in ships)
                    {
                        if (ship.CointainsVector(new Vector2d(x, y)))
                        {
                            isBoard = true;
                        }
                    }
                    if (isBoard)
                    {
                        board += "X";
                    }
                    else
                    {
                        board += ".";
                    }
                }
                if (x != boardSize - 1)
                {
                    board += "\r\n" + alphabet[x + 1] + " ";
                }
            }
            return board;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">input from keyboard</param>
        /// <returns></returns>
        public string Interact(string input)
        {
            if (input.ToLower() == "r")
            {
                RestartGame();
                return " NEW GAME BATTLESHIPS \r\n \r\n a0/i9-hit \r\n r-restart q-exit \r\n \r\n" + DrawBoard()+"\r\n";
            }

            try
            {
                VectorParser.ParseVector(input);
            }
            catch (Exception)
            {

                return "???? (a0/i9-hit  r-restart q-exit)";
            }
            Vector2d hitPos = VectorParser.ParseVector(input);
            string message = "";
            bool allMissed = true;
            bool allDead = true;
            foreach (var ship in ships)
            {
                HitResult hitResult= ship.HitAt(hitPos);
                if (hitResult.HitState!= HitState.miss)
                {
                    allMissed=false;
                    message = hitResult.GetDescription();
                }
                if (!ship.IsDestroyed())
                {
                    allDead= false;
                }
            }
            if (allMissed)
            {
                message = "YOU MISS :(";
            }
            if (allDead)
            {
                message = "YOU WIN :)";
            }
            return message;

        }


    }
}

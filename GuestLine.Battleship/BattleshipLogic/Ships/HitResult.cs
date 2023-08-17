using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestLine.Battleship.BattleshipLogic.Tools;

namespace GuestLine.Battleship.BattleshipLogic.Ships
{
    internal class HitResult
    {
        private HitState hitState;
        private Vector2d vector2D;
        private Ship ship;

        public HitResult(HitState hitState, Vector2d vector2D, Ship ship)
        {
            this.ship = ship;
            this.hitState = hitState;
            this.vector2D = vector2D;
        }

        internal HitState HitState { get => hitState;  }

        public string GetDescription()
        {
            string message = "";
            if (hitState== HitState.hit)
            {
                message += "YOU HIT: ";
            }
            if (hitState == HitState.sink)
            {
                message += "YOU SINK: ";
            }
            if (ship.Length()==5)
            {
                message += "Battleship";
            }
            if (ship.Length() == 4)
            {
                message += "Destroyer";
            }

            return message;
        }

    }
}

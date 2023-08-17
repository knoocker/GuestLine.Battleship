using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestLine.Battleship.BattleshipLogic.Tools;

namespace GuestLine.Battleship.BattleshipLogic.Ships
{
    internal class ShipElement
    {


        public ShipElement(Vector2d vector2D) { 
        
            this.vector2D = vector2D;
        }
        Vector2d vector2D;

        public bool IsHited { get => isHited; set => isHited = value; }
        internal Vector2d Vector2D { get => vector2D; }

        private bool isHited = false;

    }
}

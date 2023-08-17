using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestLine.Battleship.BattleshipLogic.Tools;

namespace GuestLine.Battleship.BattleshipLogic.Ships
{
    internal class Ship
    {
        private List<ShipElement> elements;

        public Ship(List<Vector2d> vector2Ds)
        {
            elements = new List<ShipElement>();
            foreach (var vector2d in vector2Ds)
            {
                elements.Add(new ShipElement(vector2d));
            }
        }

        public int Length()
        {
            return elements.Count;
        }


        public bool IsDestroyed()
        {
            foreach (var element in elements)
            {
                if (!element.IsHited)
                {
                    return false;
                }
            }
            return true;
        }


        public bool CointainsVector(Vector2d vector2D)
        {
            foreach (var element in elements)
            {
                if (element.Vector2D.IsEqual(vector2D))
                {
                    return true;
                }
            }
            return false;
        }

        public HitResult HitAt(Vector2d vector2D)
        {
            foreach (var element in elements)
            {
                if (element.Vector2D.IsEqual(vector2D))
                {
                    element.IsHited = true;
                    if (IsDestroyed())
                    {
                        return new HitResult(HitState.sink, vector2D,this);
                    }
                    else
                    {
                        return new HitResult( HitState.hit, vector2D,this);
                    }
                }
            }
            return new HitResult( HitState.miss, vector2D,this);
        }


    }
}

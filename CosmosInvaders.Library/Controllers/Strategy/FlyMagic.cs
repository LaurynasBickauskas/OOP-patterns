using System;

namespace CosmosInvaders.Library
{
    public class FlyMagic : FlyAlgorithm
    { 
        public void Move(ref int x, ref int y, FlyingDirection previousDir, FlyingDirection newDir, ref int speed)
        {
            if (newDir == FlyingDirection.Up)
            {
                y -= 5;
            }
            else if (newDir == FlyingDirection.Down)
            {
                y += 5;
            }
            else if (newDir == FlyingDirection.Right)
            {
                x += 10;
            }
            else if (newDir == FlyingDirection.Left)
            {
                x -= 10;
            }
            NotifyOtherDestroyers();
        }


        public void NotifyOtherDestroyers()
        {
            Game.Instance.ObservableShips.NotifyAll();
        }
    }
}
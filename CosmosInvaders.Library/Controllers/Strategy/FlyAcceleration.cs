using System;

namespace CosmosInvaders.Library
{
    public class FlyHit : FlyAlgorithm
    {
        public (int x, int y, int speed) Move(int x, int y, FlyingDirection previousDir, FlyingDirection newDir, int speed)
        {
            if(previousDir == newDir)
            {
                if (newDir == FlyingDirection.Up)
                {
                    y += (int)speed;
                }
                else if (newDir == FlyingDirection.Down)
                {
                    y -= (int)speed;
                }
                else if (newDir == FlyingDirection.Right)
                {
                    x += (int)speed;
                }
                else if (newDir == FlyingDirection.Left)
                {
                    x -= (int)speed;
                }
                return (x, y, speed++);
            }
            NotifyOtherDestroyers();
            return (x, y,speed);
        }


        public void NotifyOtherDestroyers()
        {
            Game.Instance.ObservableShips.NotifyAll();
        }
    }
}
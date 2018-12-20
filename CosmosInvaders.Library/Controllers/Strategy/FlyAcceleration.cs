using System;

namespace CosmosInvaders.Library
{
    public class FlyAcceleration : FlyAlgorithm
    {
        public void  Move(ref int x, ref int y, FlyingDirection previousDir, FlyingDirection newDir,ref int speed)
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
                speed++;
            }
            else
            {
                speed = 0;
            }
            NotifyOtherDestroyers();
        }


        public void NotifyOtherDestroyers()
        {
            Game.Instance.ObservableShips.NotifyAll();
        }
    }
}
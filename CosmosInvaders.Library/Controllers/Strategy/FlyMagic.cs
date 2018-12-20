using System;

namespace CosmosInvaders.Library
{
    public class FlyMagic : FlyAlgorithm
    {
        public (int x, int y, int speed) Move(int x, int y, FlyingDirection previousDir, FlyingDirection newDir, int speed)
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
            return (x, y,speed);
        }


        public void NotifyOtherDestroyers()
        {
            Game.Instance.ObservableShips.NotifyAll();
        }
    }
}
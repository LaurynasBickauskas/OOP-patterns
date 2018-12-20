using System;

namespace CosmosInvaders.Library
{
    public class FlyRegular : FlyAlgorithm
    {
        protected override int CalculateMovement(double p, double speed)
        {
            return (int)Math.Floor(p * speed) + 1;
        }

        protected override void NotifyOtherDestroyers()
        {
            Game.Instance.ObservableShips.NotifyAll();
        }
    }
}
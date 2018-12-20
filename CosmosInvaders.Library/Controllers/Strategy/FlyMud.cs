using System;

namespace CosmosInvaders.Library
{
    public class FlyHit : FlyAlgorithm
    {
        protected override int CalculateMovement(double p, double speed)
        {
            return (int)Math.Floor(p * Math.Sqrt(speed));
        }

        protected override void NotifyOtherDestroyers()
        {
            Game.Instance.ObservableShips.NotifyAll();
        }
    }
}
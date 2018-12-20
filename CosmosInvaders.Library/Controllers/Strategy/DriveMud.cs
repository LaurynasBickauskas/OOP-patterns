using System;

namespace CosmosInvaders.Library
{
    public class DriveMud : DriveAlgorithm
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
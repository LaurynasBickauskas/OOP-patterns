using System;

namespace CosmosInvaders.Library
{
    public class DriveRegular : DriveAlgorithm
    {
        protected override int CalculateMovement(double p, double speed)
        {
            return (int)Math.Floor(p * speed) + 1;
        }

        protected override void NotifyOtherCars()
        {
            Game.Instance.ObservableVehicles.NotifyAll();
        }
    }
}
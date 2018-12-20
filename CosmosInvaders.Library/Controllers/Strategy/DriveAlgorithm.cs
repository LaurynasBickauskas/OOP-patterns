using System;

namespace CosmosInvaders.Library
{
    public abstract class DriveAlgorithm
    {
        private const double _straightMovementParameter = 1;

        public (int x, int y) Move(int x, int y, DrivingDirection direction, double speed)
        {
            switch (direction)
            {
                case DrivingDirection.Left:
                    x -= CalculateMovement(_straightMovementParameter, speed);
                    break;

                case DrivingDirection.Up:
                    y -= CalculateMovement(_straightMovementParameter, speed);
                    break;

                case DrivingDirection.Right:
                    x += CalculateMovement(_straightMovementParameter, speed);
                    break;

                case DrivingDirection.Down:
                    y += CalculateMovement(_straightMovementParameter, speed);
                    break;
            }

            if (y > 590) y = 590;
            if (y < 0) y = 0;
            if (x > 560) x = 560;
            if (x < 0) x = 0;

            NotifyOtherCars();
            return (x, y);
        }

        protected abstract int CalculateMovement(double p, double speed);

        protected abstract void NotifyOtherCars();
    }
}
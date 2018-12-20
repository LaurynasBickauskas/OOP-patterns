using System;

namespace CosmosInvaders.Library
{
    public abstract class FlyAlgorithm
    {
        private const double _straightMovementParameter = 1;

        public (int x, int y) Move(int x, int y, FlyingDirection direction, double speed)
        {
            switch (direction)
            {
                case FlyingDirection.Left:
                    x -= CalculateMovement(_straightMovementParameter, speed);
                    break;

                case FlyingDirection.Up:
                    y -= CalculateMovement(_straightMovementParameter, speed);
                    break;

                case FlyingDirection.Right:
                    x += CalculateMovement(_straightMovementParameter, speed);
                    break;

                case FlyingDirection.Down:
                    y += CalculateMovement(_straightMovementParameter, speed);
                    break;
            }

            if (y > 590) y = 590;
            if (y < 0) y = 0;
            if (x > 560) x = 560;
            if (x < 0) x = 0;

            NotifyOtherDestroyers();
            return (x, y);
        }

        protected abstract int CalculateMovement(double p, double speed);

        protected abstract void NotifyOtherDestroyers();
    }
}
using System;

namespace CosmosInvaders.Library
{
    abstract class AbstractLogger
    {
        public static int ZERO_SPEED = 1;
        public static int SPEED_LIMIT = 2;
        public static int MAX_SPEED = 3;

        protected int level;

        protected AbstractLogger nextLogger;

        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public void LogMessage(int level, Vehicle vehicle, GameFacade facade)
        {
            if (this.level <= level)
            {
                Write(vehicle, facade);
            }
            else if (nextLogger != null)
            {
                nextLogger.LogMessage(level, vehicle, facade);
            }
        }
        abstract protected void Write(Vehicle vehicle, GameFacade facade);
    }
}

namespace Racing2D.Library
{
    internal class SpeedLimitLogger : AbstractLogger
    {
        public SpeedLimitLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(Vehicle vehicle, GameFacade facade)
        {
            facade.message = "Žaidėjas: [" + vehicle.PlayerName + "] viršijo leistiną 25 km/h greitį";
        }
    }
}
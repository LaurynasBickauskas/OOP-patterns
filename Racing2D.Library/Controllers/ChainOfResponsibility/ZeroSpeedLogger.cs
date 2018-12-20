namespace Racing2D.Library
{
    class ZeroSpeedLogger : AbstractLogger
    {
        public ZeroSpeedLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(Vehicle vehicle, GameFacade facade)
        {
            facade.message= "Žaidėjas: [" + vehicle.PlayerName + "] sustojo trasoje";
        }
    }
}

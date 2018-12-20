namespace CosmosInvaders.Library
{
    class MaxSpeedLogger : AbstractLogger
    {
        public MaxSpeedLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(Vehicle vehicle, GameFacade facade)
        {
            facade.message = "Žaidėjas: [" + vehicle.PlayerName + "] pasiekė savo maksimalų greitį - " + vehicle.MaxSpeed + " km/h";
        }
    }
}

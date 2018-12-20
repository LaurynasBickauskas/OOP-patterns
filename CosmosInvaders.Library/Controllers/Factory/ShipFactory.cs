namespace CosmosInvaders.Library
{
    /// <summary>
    /// Abstract factory
    /// </summary>
	public class ShipFactory : AbstractShipFactory
    {
        RangerFactory _rangerFactory { get; set; }
        DestroyerFactory _destroyerFactory { get; set; }

        public ShipFactory()
        {
            _rangerFactory = new RangerFactory();
            _destroyerFactory = new DestroyerFactory();
        }

        /// <summary>
        /// Get ship
        /// </summary>
		public override Ship GetShip(string playerName, string family, string type)
        {
            Ship ship = null;
            switch (family)
            {
                case "Ranger":
                    ship = (Ship)_rangerFactory.GetRanger(type);
                    ship.SetCoordinates(200, 200);
                    ship.PlayerName = playerName;
                    ship.HealthPoints = ship.MaxHealthPoints;
                    return ship;
                case "Destroyer":
                    ship = (Ship)_destroyerFactory.GetDestroyer(type);
                    ship.SetCoordinates(200, 200);
                    ship.PlayerName = playerName;
                    ship.HealthPoints = ship.MaxHealthPoints;
                    return ship;
                default:
                    return ship;
            }
        }

    }

}

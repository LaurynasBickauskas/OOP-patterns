namespace CosmosInvaders.Library
{
    /// <summary>
    /// Abstract factory
    /// </summary>
	public class VehicleFactory : AbstractVehicleFactory
    {
        RangerFactory _rangerFactory { get; set; }
        DestroyerFactory _destroyerFactory { get; set; }

        public VehicleFactory()
        {
            _rangerFactory = new RangerFactory();
            _destroyerFactory = new DestroyerFactory();
        }

        /// <summary>
        /// Get vehicle
        /// </summary>
		public override Vehicle GetVehicle(string playerName, string family, string type)
        {
            Vehicle vehicle = null;
            switch (family)
            {
                case "Ranger":
                    vehicle = (Vehicle)_rangerFactory.GetRanger(type);
                    vehicle.SetCoordinates(200, 200);
                    vehicle.PlayerName = playerName;
                    vehicle.HealthPoints = vehicle.MaxHealthPoints;
                    return vehicle;
                case "Destroyer":
                    vehicle = (Vehicle)_destroyerFactory.GetDestroyer(type);
                    vehicle.SetCoordinates(200, 200);
                    vehicle.PlayerName = playerName;
                    vehicle.HealthPoints = vehicle.MaxHealthPoints;
                    return vehicle;
                default:
                    return vehicle;
            }
        }

    }

}

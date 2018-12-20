namespace CosmosInvaders.Library
{
    /// <summary>
    /// Abstract factory
    /// </summary>
	public class VehicleFactory : AbstractVehicleFactory
    {
        BikeFactory _bikeFactory { get; set; }
        CarFactory _carFactory { get; set; }

        public VehicleFactory()
        {
            _bikeFactory = new BikeFactory();
            _carFactory = new CarFactory();
        }

        /// <summary>
        /// Get vehicle
        /// </summary>
		public override Vehicle GetVehicle(string playerName, string family, string type)
        {
            Vehicle vehicle = null;
            switch (family)
            {
                case "Bike":
                    vehicle = (Vehicle)_bikeFactory.GetBike(type);
                    vehicle.SetCoordinates(200, 200);
                    vehicle.PlayerName = playerName;
                    vehicle.HealthPoints = vehicle.MaxHealthPoints;
                    return vehicle;
                case "Car":
                    vehicle = (Vehicle)_carFactory.GetCar(type);
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

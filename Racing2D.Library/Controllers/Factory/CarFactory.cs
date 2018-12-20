namespace Racing2D.Library
{
    public class CarFactory
    {
        public ICar GetCar(string type)
        {
            switch (type)
            {
                case "Jeep":
                    return new Jeep().GetCar();
                case "RaceCar":
                    return new RaceCar().GetCar();
                case "Truck":
                    return new Truck().GetCar();
                default:
                    return null;
            }
        }

    }

}
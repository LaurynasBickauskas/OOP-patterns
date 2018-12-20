namespace CosmosInvaders.Library
{
    public class RaceCar : Vehicle, ICar
    {
        private const int _maxHealthPoints = 100;
        private const int _maxSpeed = 60;

        public RaceCar()
        {
            MaxSpeed = _maxSpeed;
            MaxHealthPoints = _maxHealthPoints;
        }

        public ICar GetCar()
        {
            return this;
        }
    }
}

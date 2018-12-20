namespace CosmosInvaders.Library
{
    public class Truck : Vehicle, ICar
    {
        private const int _maxHealthPoints = 120;
        private const int _maxSpeed = 40;

        public Truck()
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

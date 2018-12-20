namespace CosmosInvaders.Library
{
    public class Bicycle : Vehicle, IBike
    {
        private const int _maxHealthPoints = 70;
        private const int _maxSpeed = 10;

        public Bicycle()
        {
            MaxSpeed = _maxSpeed;
            MaxHealthPoints = _maxHealthPoints;
        }

        public IBike GetBike()
        {
            return this;
        }
    }
}

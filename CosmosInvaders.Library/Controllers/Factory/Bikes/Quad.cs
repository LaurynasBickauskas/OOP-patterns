namespace CosmosInvaders.Library
{
    public class Quad : Vehicle, IBike
    {
        private const int _maxHealthPoints = 90;
        private const int _maxSpeed = 30;

        public Quad()
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

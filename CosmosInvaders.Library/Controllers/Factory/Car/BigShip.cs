namespace CosmosInvaders.Library
{
    public class BigShip : Ship, IDestroyer
    {
        private const int _maxHealthPoints = 150;
        private const int _maxSpeed = 20;

        public BigShip()
        {
            MaxSpeed = _maxSpeed;
            MaxHealthPoints = _maxHealthPoints;
        }

        public IDestroyer GetDestroyer()
        {
            return this;
        }
    }
}

namespace CosmosInvaders.Library
{
    public class MediumShip : Ship, IDestroyer
    {
        private const int _maxHealthPoints = 100;
        private const int _maxSpeed = 30;

        public MediumShip()
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

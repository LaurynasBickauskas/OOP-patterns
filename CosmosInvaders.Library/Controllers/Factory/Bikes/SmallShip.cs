namespace CosmosInvaders.Library
{
    public class SmallShip : Ship, IRanger
    {
        private const int _maxHealthPoints = 70;
        private const int _maxSpeed = 50;

        public SmallShip()
        {
            MaxSpeed = _maxSpeed;
            MaxHealthPoints = _maxHealthPoints;
        }

        public IRanger GetRanger()
        {
            return this;
        }
    }
}

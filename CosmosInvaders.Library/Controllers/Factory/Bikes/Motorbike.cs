namespace Racing2D.Library
{
    public class Motorbike : Vehicle, IBike
    {
        private const int _maxHealthPoints = 80;
        private const int _maxSpeed = 20;

        public Motorbike()
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

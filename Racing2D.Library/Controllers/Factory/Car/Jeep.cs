namespace Racing2D.Library
{
    public class Jeep : Vehicle, ICar
    {
        private const int _maxHealthPoints = 110;
        private const int _maxSpeed = 50;

        public Jeep()
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

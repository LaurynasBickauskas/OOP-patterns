namespace Racing2D.Library
{
    public abstract class Obstacle
    {
        public int UpperLeftCoordinateX { get; set; }
        public int UpperLeftCoordinateY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Damage { get; set; }

        public abstract Obstacle Clone();

    }
}

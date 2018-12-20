using System;

namespace CosmosInvaders.Library
{
    public class Rock : Obstacle
    {
        public Rock()
        {
            UpperLeftCoordinateX = 0;
            UpperLeftCoordinateY = 0;
            Damage = 10;
            Height = 1;
            Width = 1;
        }

        public override Obstacle Clone()
        {
            return (Obstacle)this.MemberwiseClone();
        }
    }
}

using System;

namespace CosmosInvaders.Library
{
    public class Tree : Obstacle
    {
        public Tree()
        {
            UpperLeftCoordinateX = 0;
            UpperLeftCoordinateY = 0;
            Damage = 15;
            Height = 1;
            Width = 2;
        }

        public override Obstacle Clone()
        {
            return (Obstacle)this.MemberwiseClone();
        }
    }
}

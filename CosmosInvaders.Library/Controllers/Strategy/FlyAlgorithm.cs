using System;

namespace CosmosInvaders.Library
{
    public interface FlyAlgorithm
    {
        void Move(ref int x, ref int y, FlyingDirection previousDir, FlyingDirection newDir, ref int speed);
    }
}
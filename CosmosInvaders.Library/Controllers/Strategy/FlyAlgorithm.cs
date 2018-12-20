using System;

namespace CosmosInvaders.Library
{
    public interface FlyAlgorithm
    {
        (int x, int y, int speed) Move(int x, int y, FlyingDirection previousDir, FlyingDirection newDir, int speed);
    }
}
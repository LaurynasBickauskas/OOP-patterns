using CosmosInvaders.Library;
using System.Collections.Generic;

namespace CosmosInvaders.Client
{
    public interface IDraw
    {
        void DrawShips(List<Vehicle> vehicles);
    }
}
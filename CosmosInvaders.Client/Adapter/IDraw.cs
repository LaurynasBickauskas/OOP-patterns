using Racing2D.Library;
using System.Collections.Generic;

namespace Racing2D.Client
{
    public interface IDraw
    {
        void DrawCars(List<Vehicle> vehicles);
    }
}
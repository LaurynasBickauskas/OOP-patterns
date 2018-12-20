using CosmosInvaders.Library;
using System.Drawing;

namespace CosmosInvaders.Client.Visitor
{
    public interface IShipTypeVisitor
    {
        Bitmap Visit(Bikes.Bicycle bicycle, FlyingDirection direction);

        Bitmap Visit(Bikes.Motorbike motorbike, FlyingDirection direction);

        Bitmap Visit(Bikes.Quad quad, FlyingDirection direction);

        Bitmap Visit(Cars.Jeep jeep, FlyingDirection direction);

        Bitmap Visit(Cars.RaceCar careCar, FlyingDirection direction);

        Bitmap Visit(Cars.Truck truck, FlyingDirection direction);
    }
}